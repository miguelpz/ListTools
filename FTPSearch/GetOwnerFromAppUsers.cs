using FTPSearch.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch
{
    public class GetOwnerFromAppUsers
    {

        private List<MatchDTO> _usersList;

        string URI = @ConfigurationManager.AppSettings["JiraEndPoint"];

        public  GetOwnerFromAppUsers(List<MatchDTO> usersList)
        {
            _usersList = usersList;
        }


        public List<MatchDTO> GetAll()
        {
            foreach (MatchDTO user in _usersList)
            {
                if (user.Application.Count > 0)
                {
                    string myParameters = JsonConvert.SerializeObject(user.Application);

                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                        var HtmlResult = wc.UploadString(URI, myParameters);
                        List<string> appOwner;
                        appOwner = JsonConvert.DeserializeObject<List<string>>(HtmlResult);
                        appOwner = appOwner.Distinct().ToList();

                        foreach (string owner in appOwner)
                        {
                            string[] segments = owner.Split('/');
                            var teamOwner = segments[segments.Length - 1];
                            if (!user.Owner.Contains(teamOwner) && !string.IsNullOrEmpty(teamOwner))
                            {
                                user.Owner.Add(teamOwner);
                            }
                                
                        }

                    }
                }
            }

            return _usersList;
        }
           
    }
}
