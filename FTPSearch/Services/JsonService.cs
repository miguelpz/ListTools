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
        public void SaveToJson<T>(string fileKeyConfig, List<T> list)
        {
            using (StreamWriter file = File.CreateText(@ConfigurationManager.AppSettings[fileKeyConfig]))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, list);
            }
        }

        public List<MatchDTO> LoadToJson()
        {
            return JsonConvert.DeserializeObject<List<MatchDTO>>(File.ReadAllText(@ConfigurationManager.AppSettings["JsonFile"]));
        }

        public List<T> LoadJson<T>(string jsonNameFile)
        {
            string WorkSpacePath = @ConfigurationManager.AppSettings["WorkSpace"];

            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(@WorkSpacePath + jsonNameFile));
        }

        public void SaveJson<T>(string jsonNameFile, List<T> list)
        {
            string WorkSpacePath = @ConfigurationManager.AppSettings["WorkSpace"];

            using (StreamWriter file = File.CreateText(@WorkSpacePath + jsonNameFile))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, list);
            }
        }




        public IEnumerable<string> LoadListJsonFile(string fileName)
        {
            return JsonConvert.DeserializeObject<IEnumerable<string>>(File.ReadAllText(@ConfigurationManager.AppSettings["JsonListFile"] + fileName));
        }
    }
}
