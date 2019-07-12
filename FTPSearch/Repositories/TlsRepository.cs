using FTPSearch.Contracts;
using FTPSearch.DTO;
using FTPSearch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Repositories
{
    public class TlsRepository:ITlsRepository
    {
        private IExcelIOService _excelIOService;
        private const string fileKeyConfig = "TlsExcelFile";


        public TlsRepository(IExcelIOService excelIOService)
        {
            _excelIOService = excelIOService;
        }


        

        public IEnumerable<TlsTaskModelData> GetDataExcelFile()
        {
            List<string> IssueKeys = _excelIOService.GetAllNamesInColumn(fileKeyConfig, 1, 2, true).ToList();
            List<string> appNames = _excelIOService
                .GetAllNamesInColumn(fileKeyConfig, 1, 3, true).Select(o =>
                    o = StringOperationsHelper.DeleteString(o, "Actualizar FrameWork y desabilitar forzado TLS ")).ToList();

            List<TlsTaskModelData> tlsTaskModelDataList = new List<TlsTaskModelData>();

            for (int x = 0; x < IssueKeys.Count - 1; x++)
            {
                tlsTaskModelDataList.Add(

                   new TlsTaskModelData()
                   {
                       key = IssueKeys[x],
                       appName = appNames[x]
                   });
            }

            return tlsTaskModelDataList;
        }






             





    }
}
