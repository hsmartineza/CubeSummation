using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CubeSummation.Models
{
    public class Cube
    {

        private static IDictionary<string, long> CubeDict = new Dictionary<string, long>();

        public int size
        {
            get;
            set;
        }


        public int MaxSize()
        {
            return size * size * size;

        }

        public void ClearCube()
        {

            CubeDict.Clear();
        }


        public void Update(int x, int y, int z, int val)
        {
            string key = x.ToString() + " " + y.ToString() + " " + z.ToString();

            if (CubeDict.ContainsKey(key))
            {
                CubeDict[key] = val;
            }
            else
            {
                CubeDict.Add(key, val);

            }


        }

        public long Query(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            long sum = 0;

            foreach (var block in CubeDict)
            {
                string[] index = block.Key.Split(' ');
                int x = int.Parse(index[0]);
                int y = int.Parse(index[1]);
                int z = int.Parse(index[2]);

                if ((x1 <= x && x <= x2) && (y1 <= y && y <= y2) && (z1 <= z && z <= z2))
                    sum = sum + block.Value;

            }

            return sum;
        }

    }
}
