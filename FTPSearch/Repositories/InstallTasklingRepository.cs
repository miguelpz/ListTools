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
    public class InstallTasklingRepository : IMassiveRepository
    {
        private IExcelIOService _excelIOService;
        private const string fileKeyConfig = "InstalTasklingExcelFile";


        public InstallTasklingRepository(IExcelIOService excelIOService)
        {
            _excelIOService = excelIOService;
        }


        

        public IEnumerable<TaskModelData> GetDataExcelFile()
        {
            List<string> IssueKeys = _excelIOService.GetAllNamesInColumn(fileKeyConfig, 1, 2, true).ToList();
            List<string> appNames = _excelIOService
                .GetAllNamesInColumn(fileKeyConfig, 1, 3, true).Select(o =>
                    o = StringOperationsHelper.DeleteString(o, "Instalar Taskling en  ")).ToList();

            List<TaskModelData> TaskModelDataList = new List<TaskModelData>();

            for (int x = 0; x < IssueKeys.Count - 1; x++)
            {
                TaskModelDataList.Add(

                   new TaskModelData()
                   {
                       key = IssueKeys[x],
                       appName = appNames[x]
                   });
            }

            return TaskModelDataList;
        }






             





    }
}
