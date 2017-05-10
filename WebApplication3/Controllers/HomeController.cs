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

        public ActionResult rootAds(string id)
        {
            Console.WriteLine("id = {0}", id);
            var fn = "indexemail.html";
            if (!string.IsNullOrEmpty(id))
            {
                fn = id+".html";
            }
            var url = string.Format("~/Views/Home/{0}", fn);
            var result = new FilePathResult(url, "text/html");
            //var result = new FilePathResult("~/Views/Home/indexemail.html", "text/html");
            return result;
        }

        public ActionResult homelessAds()
        {
            var result = new FilePathResult("~/Views/Home/homelessad.html", "text/html");
            return result;
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
