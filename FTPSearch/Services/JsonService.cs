using FTPSearch.Contracts;
using FTPSearch.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Services
{
    public class JsonService:IJsonService
    {
        public void SaveToJson(List<MatchDTO> list)
        {
            using (StreamWriter file = File.CreateText(@ConfigurationManager.AppSettings["JsonFile"]))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, list);
            }
        }

        public List<MatchDTO> LoadToJson()
        {
            return JsonConvert.DeserializeObject<List<MatchDTO>>(File.ReadAllText(@ConfigurationManager.AppSettings["JsonFile"]));
        }
    }
}
