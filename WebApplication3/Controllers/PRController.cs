using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    public class PRController : ApiController
    {
        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        [Route("api/mytest")]
        // GET: api/PR/mytest
        public async Task<HttpResponseMessage> MyTest(HttpRequestMessage request)
        {
           var jsonString = await request.Content.ReadAsStringAsync();

            string yourJson = "{ success: \"true\" }";
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Content = new StringContent(yourJson, Encoding.UTF8, "application/json");
            //resp.Content = new StringContent(o, Encoding.UTF8, "application/json");
            //return response;
            return resp; // new HttpResponseMessage(HttpStatusCode.OK); 
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
