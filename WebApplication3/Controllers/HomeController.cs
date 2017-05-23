using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Other;

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

        public ActionResult letsDoThis(string id)
        {
            Debug.WriteLine("id = {0}", id);
            //var fn = "indexemail.html";
            //if (!string.IsNullOrEmpty(id))
            //{
            //    fn = id + ".html";
            //}
            //var url = string.Format("~/Views/Home/{0}", fn);
            //var result = new FilePathResult(url, "text/html");
            //var result = new FilePathResult("~/Views/Home/indexemail.html", "text/html");
            //return "Holly rart shit Robbin."//result;

            RestSharp.IRestResponse ir = MyMail.SendSimpleMessage();
            Console.WriteLine(ir.Content);
            Debug.WriteLine(ir.Content);

            // FM begin 5/22/17
            string strJson = string.Empty;
            myhelpers.MyHelpers.ReadFromApp_Data("~/App_Data/employees.json", ref strJson);
            //resp.Content = new StringContent(strJson, Encoding.UTF8, "application/json");
            // Fm end 5/22/17

            //var res = "{\"ass\": \"Holly rart shit Robbin.\"}";
            var res = strJson;

            return Content(res.ToString(), "application/json");
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
