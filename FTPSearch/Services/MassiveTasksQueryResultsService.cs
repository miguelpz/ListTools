using FTPSearch.DTO;
using FTPSearch.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Services
{
    public class MassiveTasksQueryResultsService
    {
        private List<TaskModelData> totalResults;

        private JsonService js;
        private MassiveTasksService ms;

        private string DataBaseFileNameResult = "DataBaseFileResult.json";
        private string UpdatePoolFileNameResult = "UpdatePoolFileResult.json";
        private string AppFabricFileNameResult = "AppFabricFileResult.json";
        private string TlsFileNameResult = "TlsFileResult.json";
        private string InstallTasklingFileNameResult = "InstallTasklingFileResult.json";
        private string UpdateTasklingFileNameResult = "UpdateTasklingFileResult.json";

        public MassiveTasksQueryResultsService()
        {
            js = new JsonService();
            ms = new MassiveTasksService(new MassiveTaskRepository(new ExcelIOService()), new JsonService(), new JiraRepository());
            totalResults = new List<TaskModelData>();
        }


        public void GenerateDataBaseResult()
        {
            GetResult(ms.GetDataBaseListDTO(), DataBaseFileNameResult);
        }

        public void GenerateTlsResult()
        {
            GetResult(ms.GetTlsListDTO(), TlsFileNameResult);
        }

        public void GenerateInstallTasklingResult()
        {
            GetResult(ms.GetInstallTasklingListDTO(), InstallTasklingFileNameResult);
        }

        public void GenerateUpdateTasklingResult()
        {
            GetResult(ms.GetUpdateTasklingListDTO(), UpdateTasklingFileNameResult);
        }

        public void GenerateUpdatePoolResult()
        {
            GetResult(ms.GetUpdatePoolListDTO(), UpdatePoolFileNameResult);
        }

        public void GenerateAppFabricPoolResult()
        {
            GetResult(ms.GetAppfabricTasklingListDTO(), AppFabricFileNameResult);
        }










        public void AddFoundTeamList (List<TaskModelData> taskList)
        {

            totalResults.AddRange(taskList);
        }


        public void ClearLists()
        {
            totalResults.Clear();
        }
       

        public void GenerateTlsResults()
        {

        }





        public string GetAllTeams()
        {
            var result = from TaskModelData in totalResults
                            group TaskModelData by TaskModelData.team into g
                            select new
                            {
                                team = g.Key,
                                tasks = totalResults.Where(o => o.team == g.Key).Select(o => o.key).ToList()

                            };

            return JsonConvert.SerializeObject(result);
        }

        public void GetResult(IEnumerable<TaskModelData> teamTasks,string fileName)
        {
            var result = from TaskModelData in teamTasks
                         group TaskModelData by TaskModelData.team into g
                         select new ResultModel()
                         {
                             team = g.Key,
                             tasks = teamTasks.Where(o => o.team == g.Key).Select(o => o.key).ToList()
                        };

            js.SaveJson<ResultModel>(fileName, (List<ResultModel>)result.ToList());
         
        }
       


    }
}
