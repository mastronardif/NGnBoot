using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace mvc6.Controllers
{
    public class PingController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [Route("api/MyPing")]
        public async Task<HttpResponseMessage> MyPing(HttpRequestMessage request)

        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            
            string results = string.Empty;
            //resp.Content = new StringContent(o, Encoding.UTF8, "application/json");
            //return response;
           // KeyValuePair<string, string> keyvalues = new KeyValuePair<string, string>();
            var query = request.GetQueryNameValuePairs().ToArray();
            Console.WriteLine(query.ToString());
            String jaQueryparams = "[" + String.Join(",", query.Select(
                kvp => //"-" + "{\"" + kvp.Value + 
                            string.Format("{{\"{0}\":\"{1}\"}}", kvp.Key, kvp.Value))) + "]";

            var jsonString = await request.Content.ReadAsStringAsync();
            //string jsonString = await request.Content.ReadAsStringAsync();
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

            //resp.Content = new StringContent("{}", Encoding.UTF8, "application/json");
            resp.Content = new StringContent(yourJson, Encoding.UTF8, "application/json");

            return resp; // new HttpResponseMessage(HttpStatusCode.OK);
        }



        [Route("customers/{customerId}/orders")]
        public string Fet(int id)
        {
            //var jsonString = await Request.Content.ReadAsStringAsync();
            var jsonString = Request.Content.ReadAsStringAsync();

            return "wtf 44 value";
        }

        // GET api/ping/5
        public string Get(int id)
        {
            return "wtf value";
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
    }
}
