using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Repositories
{
    public class JiraRepository
    {

        string URI = @ConfigurationManager.AppSettings["JiraEndPoint"];

        public string GetOwnerFromApp(string app)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var HtmlResult = wc.UploadString(URI, app);

                string result = JsonConvert.DeserializeObject<List<string>>(HtmlResult).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return "Not Found";
                }
            }
        }
    }
}
