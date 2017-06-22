using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Helpers;
using WebApplication3.Models;
using WebApplication3.Other;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        MyViewModel _model = new MyViewModel();

        public HomeController()
        {
            // Session Begin            
            //MyViewModel _model = new MyViewModel();
            //Session["users"] = model.GetUsers();
            // Session End
        }


        public ActionResult Myvm()
        {
            Session["users"] = _model.GetUsers();

            var model = new MyViewModel();
            ViewData["vd01"] = "vew data :)";
            ViewBag.thename = "Bob Jones";

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
            //throw new DivideByZeroException();
            return View("myhtml");
            //return View("mydatatables");
        }

        public ActionResult mydatatables()
        {
            return View("mydatatables");
        }

        // suppoert for datatable BEGIN

        public JsonResult GetAds(string id)
        {           
            //string content = string.Empty;
            
            JsonResult result = new JsonResult();
            try
            {
                MyViewModel model = new MyViewModel();
                var users = model.GetUsers();

                //var client = new RestClient("http://localhost:3000/");
                //var request = new RestRequest("db", Method.GET);

                //IRestResponse response = client.Execute(request);
                //response.ContentType = "application/json";

                //var content = response.Content; // raw content as string
                //content = "{'LEFT': 'right' }";                

                return(Json(users, JsonRequestBehavior.AllowGet));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            return Json("ot oh!", JsonRequestBehavior.AllowGet);
            //return Json(result.Data, JsonRequestBehavior.AllowGet);
            //return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetTableColumns(string id)
        {
            if (false)
            {
                string strJson = string.Empty;
                id = "coldefs"; // "coldefs";"tcols";
                string uri = string.Format("~/App_Data/{0}.json", id);

                myhelpers.MyHelpers.ReadFromApp_Data(uri, ref strJson);
                var res = strJson;
                return Content(res.ToString(), "application/json");
            }
            if (true)
            {
                StaticDataModel model = null;
                List<DatatableHeaderDefinition> tableData = new List<DatatableHeaderDefinition>();
                JsonResult result = new JsonResult();
                try
                {
                    string fn = HttpContext.Server.MapPath("~/App_Data/test.serial.dat");
                    model = new StaticDataModel(fn);

                    tableData = model.helperGetColDefs(); // (model.EntityTablesEditableFields); //FillingTableUtils.GetFilingTableHeader(filingParams);
                    //result = Json(tableData);
                    result = Json(tableData, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    throw;
                }
                return result;
            }

        }


        public ActionResult GetTableData(string id)
        {
            if (false)
            {
                string strJson = string.Empty;
                string uri = string.Empty; // = "~/App_Data/employees.json";
                if (!string.IsNullOrEmpty(id))
                {
                    id = "employees"; // "tdat";
                    uri = string.Format("~/App_Data/{0}.json", id);
                }
                myhelpers.MyHelpers.ReadFromApp_Data(uri, ref strJson);
                var res = strJson;
                return Content(res.ToString(), "application/json");
            }

            if (true)
            { 
            StaticDataModel model = null;
            List<Dictionary<string, object>> tableData = new List<Dictionary<string, object>>();
            JsonResult result = new JsonResult();
            try
            {
                string fn = HttpContext.Server.MapPath("~/App_Data/test.serial.dat");
                model = new StaticDataModel(fn);

                tableData = model.helperGetTableData(); // (model.EntityTablesEditableFields); //FillingTableUtils.GetFilingTableHeader(filingParams);
                DataTableResponse resp = new DataTableResponse();
                resp.data = tableData;

                result = Json(resp, JsonRequestBehavior.AllowGet);
                result.MaxJsonLength = Int32.MaxValue;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            return result;
            //return Json(data, JsonRequestBehavior.AllowGet)
            }
        }

        public ActionResult Index2detail(string id, string id2)
        {
            StaticDataModel model = null;
            //List<DatatableHeaderDefinition> tableData = new List<DatatableHeaderDefinition>();
            string retval = string.Empty;
            try
            {
                Dictionary<int, string> myDict = new Dictionary<int, string>
                {
                    { 1, "value1" },
                    { 2, "value2" },
                    { 3, "value3" },
                    { 4, "value4" }
                };
                retval = Helpers.Helpers.DictionaryToHTML_Selection("idseltest", myDict, 3);
                return Content(retval);

                string fn = HttpContext.Server.MapPath("~/App_Data/test.serial.dat");
                model = new StaticDataModel(fn);

                //model.dtTable;
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                rows = model.helperGetTableData();
                //tableData = model.helperGetColDefs(); 
                var first = rows[0];
                var cols = first.First().Value;
                //first.Values;
                //DataColumnCollection cols = (DataColumnCollection)rows.First().Values;

                //string html = Helpers.Helpers.DataTabletoHTML_Table( model.dtTable, 0);
                string html = Helpers.Helpers.DataTableRowbyColsHTML_Table(model.dtTable, 0);
                retval = html;
                //retval = Json(rows[0].Values, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }

            return Content(retval);
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
