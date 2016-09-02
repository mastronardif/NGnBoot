using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [Route("api/MethodFruit")]
        public string[] MethodFruit()
        {
            return new string[] { "Apple", "Orange", "Banana" };
        }

        public bool isValidJson(string src)
        {
            bool bRetval = true;
            try
            {
                JObject o = JObject.Parse(src);
            }
            catch
            {
                bRetval = false;
            }

            return bRetval;            
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [Route("api/MyPingTest")]
        public async Task<HttpResponseMessage> MyPing(HttpRequestMessage request)

        {
            //var jsonString = "{ success: \"true\" }";
            //return Content(HttpStatusCode.OK,  jsonString);
            // return Json(new { success = true }, JsonRequestBehavior.AllowGet);

            //Json bob = JsonConvert.SerializeObject(request.GetQueryNameValuePairs());
            
            //KeyValuePair<string, string> keyvalues = new KeyValuePair<string, string>();
            //keyvalues = request.GetQueryNameValuePairs();

            // can not hanndle duplicate keys!!             var queryString = request.GetQueryNameValuePairs().ToDictionary (x => x.Key, x => x.Value);
            //var queryString22 = request.GetQueryNameValuePairs().ToArray(x => x.Key  );
            var query = Request.GetQueryNameValuePairs().ToArray();
            Console.WriteLine(query.ToString());
            String jaQueryparams = "[" + String.Join(",", query.Select(
                kvp => //"-" + "{\"" + kvp.Value + 
                            string.Format("{{\"{0}\":\"{1}\"}}", kvp.Key, kvp.Value))) + "]";




            //int[] keys = infos.Where(kvp => kvp.Value == "Sur").Select(kvp => kvp.Key).ToArray();
            //var bilbo = query.Select(kvp => kvp.Key).ToArray();

            //var fuck = String.Join(",", query);


            //var strJJJ = request.GetQueryNameValuePairs().to ToList(x => x.Key, x => x.Value);

            //var queryString22 = request.GetQueryNameValuePairs().To(x => x.Key, x => x.Value);
            //NameValueCollection nvc = new NameValueCollection();

            //System.Web.HttpUtility.ParseQueryString( //new Uri(fullUrl).Query)

            //var nvc = (NameValueCollection)request.GetQueryNameValuePairs();
            //var dict = NvcToDictionary(nvc, true);


            //JavaScriptSerializer js = new JavaScriptSerializer();
            //string json = "{\"LEFT\": \"right\"}";
            //string json = js.Serialize(request.GetQueryNameValuePairs());
            string results;

            //results = "{ success: \"true\" }";

            var jsonString = await request.Content.ReadAsStringAsync();
            jsonString = (jsonString.Length > 0) ? jsonString : "\"\"";

            // is the body proper json or list of pairs.
            if (!isValidJson(jsonString))
            {
                ;
                //jaQueryparams = "[" + String.Join(",", jsonString.Select(
                //kvp => //"-" + "{\"" + kvp.Value + 
                //            string.Format("{{\"{0}\":\"{1}\"}}", kvp.Key, kvp.Value))) + "]";
            }
            
            results = string.Format("{{ \"query\" :{0}, \"body\" :{1} }}", jaQueryparams, jsonString);
            string yourJson = results; // "{ success: \"true\" }";
            //JObject o = JObject.Parse(yourJson);

            //var response = this.Request.CreateResponse(HttpStatusCode.OK);
            //response.Content = new StringContent(results, Encoding.UTF8, "application/json");
            //response.Content = new StringContent(yourJson, Encoding.UTF8, "application/json");

            HttpResponseMessage resp = new HttpResponseMessage();
            // response.Content = jsonString;
            //request.Content = jsonString;

            resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(yourJson, Encoding.UTF8, "application/json");
            //resp.Content = new StringContent(o, Encoding.UTF8, "application/json");
            //return response;
            return resp; // new HttpResponseMessage(HttpStatusCode.OK);
        }

        public static Dictionary<string, object> NvcToDictionary(NameValueCollection nvc, bool handleMultipleValuesPerKey)
        {
            var result = new Dictionary<string, object>();
            foreach (string key in nvc.Keys)
            {
                if (handleMultipleValuesPerKey)
                {
                    string[] values = nvc.GetValues(key);
                    if (values.Length == 1)
                    {
                        result.Add(key, values[0]);
                    }
                    else
                    {
                        result.Add(key, values);
                    }
                }
                else
                {
                    result.Add(key, nvc[key]);
                }
            }

            return result;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

/**********************
var myjson = 
{
    "qryparams": [{
        "p1": "ppp1"
    }, {
        "p1": "ppp1"
    }],
    "body": {
        "bparam1": "val1",
        "bparam2": "val2",
        "bparam2": "wtf",
        "bparam2": "apple"
    }
}
console.log(myjson); console.log(myjson.body.bparam2);

***********************/