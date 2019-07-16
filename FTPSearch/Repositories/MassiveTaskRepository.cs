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
    public class MassiveTaskRepository:IMassiveRepository
    {
        private IExcelIOService _excelIOService;

        private const string TslfileKeyConfig = "TlsExcelFile";
        private const string InstalTasklingfileKeyConfig = "InstalTasklingExcelFile";
        private const string UpdateTasklingfileKeyConfig = "UpdateTasklingExcelFile";
        private const string AppfabricfileKeyConfig = "Appfabricexcelfile";
        private const string UpdatePoolfileKeyConfig = "UpdatePoolexcelfile";
        private const string DataBasePoolexcelfile = "DataBasePoolexcelfile";





        string tslString = "Actualizar FrameWork y desabilitar forzado TLS ";
        string installTaskLingString = "Instalar Taskling en ";
        string updateTaskLingString = "Update Taskling en ";
        string appfabricString = "Migración de AppFabric a Redis ";
        string updatePoolString = "Actualizar colas MSMQ a RabbitMQ ";
        string dataBaseString = "Discrepancias en la base de datos: ";
       

        public MassiveTaskRepository(IExcelIOService excelIOService)
        {
            _excelIOService = excelIOService;
        }

        public IEnumerable<TaskModelData> GetTlsExcelData()
        {
            return GetDataExcelFile(TslfileKeyConfig, tslString);
        }

        public IEnumerable<TaskModelData> GetInstallTaskLingExcelData()
        {
            return GetDataExcelFile(InstalTasklingfileKeyConfig, installTaskLingString);
        }

        public IEnumerable<TaskModelData> GetUpdateTaskLingExcelData()
        {
            return GetDataExcelFile(UpdateTasklingfileKeyConfig, updateTaskLingString);
        }

        public IEnumerable<TaskModelData> GetAppfabricExcelData()
        {
            return GetDataExcelFile(AppfabricfileKeyConfig, appfabricString);
        }

        public IEnumerable<TaskModelData> GetUpdatePoolExcelData()
        {
            return GetDataExcelFile(UpdatePoolfileKeyConfig, updatePoolString);
        }

        public IEnumerable<TaskModelData> GetDataBaseExcelData()
        {
            return GetDataExcelFile(DataBasePoolexcelfile, dataBaseString).Select(o => new TaskModelData()
            {
                key = o.key,
                appName=o.appName.Replace("_","."),
                team=o.team
            }).ToList();
        }

        private IEnumerable<TaskModelData> GetDataExcelFile(string fileKeyConfig, string searchString)
        {
            List<string> IssueKeys = _excelIOService.GetAllNamesInColumn(fileKeyConfig, 1, 2, true).ToList();
            List<string> appNames = _excelIOService
                .GetAllNamesInColumn(fileKeyConfig, 1, 3, true).Select(o =>
                    o = StringOperationsHelper.DeleteString(o, searchString)).ToList();

            List<TaskModelData> taskModelDataList = new List<TaskModelData>();

            for (int x = 0; x < IssueKeys.Count - 1; x++)
            {
                taskModelDataList.Add(

                   new TaskModelData()
                   {
                       key = IssueKeys[x],
                       appName = appNames[x]
                   });
            }

            return taskModelDataList;
        }

    }
}
