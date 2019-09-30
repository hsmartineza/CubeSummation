using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CubeSummation.Models;


namespace CubeSummation.Services
{
    public class CubeServices
    {

        public DataViewModel GetSolution(DataViewModel data)
        {
            Cube cube = new Cube();
            List<long> result = new List<long>();

            string resulT = "";

            try
            {
                string[] dataInput = data.Input.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                int T = int.Parse(dataInput[0]);
                int indexArray = 1;


                while (T > 0)
                {
                    string input = dataInput[indexArray];
                    string[] inputSplit = input.Split(' ');
                    int N = int.Parse(inputSplit[0]);
                    int M = int.Parse(inputSplit[1]);
                    cube.size = N;
                    cube.ClearCube();
                    indexArray = indexArray + 1;

                    while (M > 0)
                    {

                        string[] operations = dataInput[indexArray].Split(' ');
                        string query = operations[0];
                        if (query == "UPDATE")
                        {
                            int x = int.Parse(operations[1]);
                            int y = int.Parse(operations[2]);
                            int z = int.Parse(operations[3]);
                            int value = int.Parse(operations[4]);
                            cube.Update(x, y, z, value);
                        }
                        else
                        {
                            int x1 = int.Parse(operations[1]);
                            int y1 = int.Parse(operations[2]);
                            int z1 = int.Parse(operations[3]);
                            int x2 = int.Parse(operations[4]);
                            int y2 = int.Parse(operations[5]);
                            int z2 = int.Parse(operations[6]);
                            result.Add(cube.Query(x1, y1, z1, x2, y2, z2));


                        }

                        M = M - 1;
                        indexArray = indexArray + 1;
                    }


                    T = T - 1;
                }

                foreach (long val in result)
                {
                    resulT += val.ToString() + "\r\n";
                }

                data.Output = resulT;
            }
            catch(Exception ex)
            {

                throw ex;
            }

          
            return data;


        }


    }
}


