using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Other;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Myvm()
        {
            var model = new MyViewModel();

            // Set the value that you want to be preselected
            model.SelectedSexPreference = "S";

            // bind the available values
            model.SexPreferences.Add("M", "Male");
            model.SexPreferences.Add("F", "Female");
            //model.SexPreferences = MemberHandler.SexPreference();

            return View(model);
        }

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

        public ActionResult mydatatables()
        {
            return View("mydatatables");
        }

        public ActionResult GetTableColumns(string id)
        {
            string strJson = string.Empty;
            myhelpers.MyHelpers.ReadFromApp_Data("~/App_Data/coldefs.json", ref strJson);

            var res = strJson;

            return Content(res.ToString(), "application/json");
        }

        public ActionResult GetTableData(string id)
        {
            string strJson = string.Empty;
            string uri = "~/App_Data/employees.json";

            if (!string.IsNullOrEmpty(id))
            {
                uri = string.Format("~/App_Data/{0}.json", id);                    
            }

            myhelpers.MyHelpers.ReadFromApp_Data(uri, ref strJson);

            var res = strJson;

            return Content(res.ToString(), "application/json");
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

            //RestSharp.IRestResponse ir = MyMail.SendSimpleMessage();
            //Console.WriteLine(ir.Content);
            //Debug.WriteLine(ir.Content);

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
