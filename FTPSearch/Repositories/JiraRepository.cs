using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Repositories
{
    public class JiraRepository: IJiraRepository
    {

        string URI = @ConfigurationManager.AppSettings["JiraEndPoint"];
        string URIJiraTicketReport = @ConfigurationManager.AppSettings["JiraTicketsReporterEndPoint"];

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

        public IEnumerable<string> GetTicketReport(IEnumerable<string> tickets)
        {
            using (WebClient wc = new WebClient())
            {



                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var HtmlResult = wc.UploadString(URIJiraTicketReport, JsonConvert.SerializeObject(tickets));

                IEnumerable<string> result = JsonConvert.DeserializeObject<IEnumerable<string>>(HtmlResult);
                return result;
            }
        }




    

        public  void SendPost (string json )
        {

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                wc.Headers[HttpRequestHeader.Accept] = "application/json";

                var HtmlResult = wc.UploadString(URI, "POST", json);

                
            }


        }



    }



}
