using FTPSearch.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Repositories
{
    public class MassiveTaskRepository
    {

        private IExcelIOService _excelIOService;
        private const string TslfileKeyConfig = "TlsExcelFile";
        private const string InstalTasklingfileKeyConfig = "InstalTasklingExcelFile";


        public MassiveTaskRepository(IExcelIOService excelIOService)
        {
            _excelIOService = excelIOService;
        }



    }
}
