using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CubeSummation.Models;
using CubeSummation.Services;


namespace CubeSummation.Controllers
{

    public class CubeController : Controller
    {
        private CubeServices cubeService { get { return new CubeServices(); } }

        // GET: Cube
        public ActionResult Problem()
        {
            ViewBag.OutPut = "";
            return View();

        }

       [HttpPost]
        public ActionResult Problem(DataViewModel data)
        {
            cubeService.GetSolution(data);
            ViewBag.OutPut = data.Output;

            return View(data);

        }

    }



}
