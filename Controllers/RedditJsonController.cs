using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace RedditSearch.Controllers
{
    public class RedditJsonController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage resp = new HttpResponseMessage();

            try
            {
                string lcUrl = "http://www.reddit.com/.json?limit=100";

                HttpWebRequest loHttp = (HttpWebRequest)WebRequest.Create(lcUrl);

                loHttp.Method = "GET";

                HttpWebResponse loWebResponse = (HttpWebResponse)loHttp.GetResponse();
                Encoding enc = Encoding.UTF8;
                StreamReader loResponseStream = new StreamReader(loWebResponse.GetResponseStream(), enc);
                StringContent lcHtml = new StringContent(loResponseStream.ReadToEnd());
                loWebResponse.Close();
                loResponseStream.Close();

                lcHtml.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                resp.Content = lcHtml;
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Reddit Seems Down");
            }
            
            return resp;

        }

    }
}
