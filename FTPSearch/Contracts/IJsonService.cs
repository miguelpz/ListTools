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
        void SaveToJson(List<MatchDTO> list);
        List<MatchDTO> LoadToJson();
    }
}
