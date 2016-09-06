using mvc6.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication3.Other;

namespace WebApplication3.Controllers
{
    public class PRController : ApiController
    {
        [CustomExceptionFilter]
        [HttpPost]
        [Route("api/fuckyou")]
        public  NameValueCollection Convert(FormDataCollection formDataCollection)
        {
            NameValueCollection MyNameValueCollection = formDataCollection.ReadAsNameValueCollection();

            IEnumerator<KeyValuePair<string, string>> pairs = formDataCollection.GetEnumerator();

            NameValueCollection collection = new NameValueCollection();

            while (pairs.MoveNext())
            {
                KeyValuePair<string, string> pair = pairs.Current;

                collection.Add(pair.Key, pair.Value);
            }
            return collection;
        }

        [HttpPost]
        [Route("api/upyours")]
        [Action1DebugActionWebApiFilter]
        public  async  Task<string> upyours(FormDataCollection formDataCollection)
        {
            NameValueCollection MyNameValueCollection = formDataCollection.ReadAsNameValueCollection();

            IEnumerator<KeyValuePair<string, string>> pairs = formDataCollection.GetEnumerator();

            NameValueCollection collection = new NameValueCollection();

            while (pairs.MoveNext())
            {
                KeyValuePair<string, string> pair = pairs.Current;

                collection.Add(pair.Key, pair.Value);
            }

            string textResult = string.Empty;
            using (var client = new HttpClient())
            {
                //var uri = new Uri("http://www.google.com/");
                var uri = new Uri("https://api.foursquare.com/v2/venues/4b4ba4faf964a520b7a226e3/menu?client_id=5GYLC30XGL2N2BUGP5MUQLE0M40XI32TIYNDGPGOFESLOP3D&client_secret=ISLE2CKXBYCGUO4FRN0B2WKKGZ2GXLRO04U4KMRCZTDWNEPA&v=20160101");

                var response = await client.GetAsync(uri);

                textResult = await response.Content.ReadAsStringAsync();
                Console.WriteLine(String.Format("textResult{0}", textResult) );
            }

           

            return textResult; // "collection";
        }

       
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [Route("api/myerrortest")]
        public string MyErrorTest(HttpRequestMessage request)
        {
            return "asdfasdf adsfasf ";
        }


        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [Route("api/mytest")]
        // GET: api/PR/mytest
        public async Task<HttpResponseMessage> MyTest(HttpRequestMessage request)
        {
            //return RedirectToAction("IndexComparison", "LifeCycleEffectsResults", model);
            //return RedirectToRoute("api/MyPingTest", null);
            //Redirect("https://google.com");
            //RedirectToAction("B",
            //      "FileUploadMsgView",
            //    new { FileUploadMsg = "File uploaded successfully" });
            //throw new Exception("wtf a simulated error!!!!");
            var message = string.Format("wtf a sim error ({0})!!!! ", "WTHA THE FUD");
            HttpError err = new HttpError(message);
            Request.CreateResponse(HttpStatusCode.NotFound, err);
            //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, err));
            throw new Exception("fuck fuck fuck");


            var jsonString = await request.Content.ReadAsStringAsync();

            string yourJson = "{ success: \"true\" }";
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(yourJson, Encoding.UTF8, "application/json");
            //resp.Content = new StringContent(o, Encoding.UTF8, "application/json");
            //return response;

            var result = await new PingController().MyPing(request); //FileUploadMsgView("some string");
            return result;
            //return Task.FromResult(result);
            //return resp; // new HttpResponseMessage(HttpStatusCode.OK); 
        }

        // GET: api/PR
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PR/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PR
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PR/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PR/5
        public void Delete(int id)
        {
        }
    }

}
