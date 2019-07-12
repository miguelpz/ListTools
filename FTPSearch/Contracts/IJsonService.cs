using FTPSearch.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Contracts
{
    public interface IJsonService
    {
        void SaveToJson<T>(string fileKeyConfig, List<T> list);
        List<MatchDTO> LoadToJson();
        IEnumerable<string> LoadListJsonFile(string fileName);
        List<T> LoadJson<T>(string jsonNameFile);
        void SaveJson<T>(string jsonNameFile, List<T> list);
    }
}
