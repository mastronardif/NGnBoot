using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Other
{
    public class MyMail
    {
        public static IRestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator = new HttpBasicAuthenticator(
                "api", "key-0-rxwnpe9gllqe6odwxebn79vicgxf76");
            RestRequest request = new RestRequest();
            request.AddParameter("domain",
                                "joeschedule.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mastronardif@gmail.com>");
            request.AddParameter("to", "mastronardif@gmail.com");
            request.AddParameter("subject", "FM, Hello");
            request.AddParameter("text", "FM, Testing some Mailgun awesomeness!");
            request.Method = Method.POST;
            return client.Execute(request);
        }

    }
}