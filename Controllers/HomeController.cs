using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCourse2017.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            throw new Exception();

            //ViewBag.Message = "ASP.NET MVC is a server-side web framework for building dynamic, data-driven web applications. Since its first release in 2009, it has gained a lot of popularity amongst developers using Microsoft technologies. If you want to get employed as a web developer at a company that utilizes Microsoft technologies, you need to master ASP.NET MVC.";
            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}