using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.DTO
{
    public class TslData
    {
        public string soluctionName;
        public List<String> frameworkPrincipal;
        public List<String> frameworkSecundaria;
        public List<String> codigoNuget;
        public List<String> codigo;

        public TslData()
        {
            frameworkPrincipal = new List<string>();
            frameworkSecundaria = new List<string>();
            codigoNuget = new List<string>();
            codigo = new List<string>();
        }
    }
}
