using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return Redirect("./mybootstrap");
            return Redirect("Home/mybootstrap");
            //ViewBag.Title = "Home Page";
            //return View();
        }

        public ActionResult myhtml()
        {
            return View("myhtml");
        }

        // /home/mybootstrap
        public ActionResult mybootstrap()
        {
            return View("mybootstrap");

        }

        // /home/myng
        public ActionResult myng()
        {
            return View("ngIndex");
            //return Redirect("Home/ngIndex");
            //return View();

        }
    }
}
