using FTPSearch.DTO;
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

        string URIJiraCreateTickets = @ConfigurationManager.AppSettings["JiraCreateTicketsEndPoint"];
        string URIJiraTicketReport = @ConfigurationManager.AppSettings["JiraTicketsReporterEndPoint"];
        string URIJiraCMDBInfo = @ConfigurationManager.AppSettings["JiraTicketsCMDBInfoEndPoint"];



        public void CreateTask (IEnumerable<TareaDTO> tasksToCreate)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(URIJiraCreateTickets);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";
            
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {                
                streamWriter.Write(JsonConvert.SerializeObject(tasksToCreate));                
                streamWriter.Flush();
            }

            var creationResult = (HttpWebResponse)httpWebRequest.GetResponse();
        }





        public string GetOwnerFromApp(string app)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var HtmlResult = wc.UploadString(URIJiraCMDBInfo, app);

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

        public IEnumerable<string> GetProductApp(IEnumerable<string> appNames)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var HtmlResult = wc.UploadString(URIJiraCMDBInfo, JsonConvert.SerializeObject(appNames));

                IEnumerable<string> result = JsonConvert.DeserializeObject<IEnumerable<string>>(HtmlResult);

                return result.ToList().Select(o => o.Split('/')[o.Split('/').Length - 4]).ToList();               
            }
        }

        public IEnumerable<string> GetTeamApp(IEnumerable<string> appNames)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var HtmlResult = wc.UploadString(URIJiraCMDBInfo, JsonConvert.SerializeObject(appNames));

                IEnumerable<string> result = JsonConvert.DeserializeObject<IEnumerable<string>>(HtmlResult);

                return result.ToList().Select(o => o.Split('/')[o.Split('/').Length - 1]).ToList();
            }
        }

        public IEnumerable<string> GetOwnerApp(IEnumerable<string> appNames)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var HtmlResult = wc.UploadString(URIJiraCMDBInfo, JsonConvert.SerializeObject(appNames));

                IEnumerable<string> result = JsonConvert.DeserializeObject<IEnumerable<string>>(HtmlResult);

                return result.ToList().Select(o => o.Split('/')[o.Split('/').Length - 2]).ToList();
            }
        }

        public IEnumerable<string> GetProjectApp(IEnumerable<string> appNames)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var HtmlResult = wc.UploadString(URIJiraCMDBInfo, JsonConvert.SerializeObject(appNames));

                IEnumerable<string> result = JsonConvert.DeserializeObject<IEnumerable<string>>(HtmlResult);

                return result.ToList().Select(o => o.Split('/')[o.Split('/').Length - 3]).ToList();
            }
        }









       



    }



}
