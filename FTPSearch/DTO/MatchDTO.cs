using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.DTO
{
    public class MatchDTO
    {
        

        private List<string> listaIds = new List<string>();
        private List<string> application = new List<string>();
        private List<string> owner = new List<string>();

        public string user = null;
        public List<string> ListaIds { get => listaIds; set => listaIds = value; }
        public List<string> Application { get => application; set => application = value; }
        public List<string> Owner { get => owner; set => owner = value; }

        public List<FTPInfo> Information { get; set; }
    }

    public class FTPInfo
    {
        public string Id { get; set;}
        public string Application { get; set; }
        public string Owner { get; set; }
    }
}
