using FTPSearch.Contracts;
using FTPSearch.DTO;
using FTPSearch.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Services
{
    public class MassiveTasksService
    {
        private readonly IMassiveRepository _massiveTaskRepository;
        

        private readonly IJsonService _jsonService;
        private readonly IJiraRepository _jiraRepository;

        private string tslWithOutNameFile = "TlsWithOutTeamFile.json";
        private string installTasklingWithOutNameFile = "InstallTasklingWithOutTeamFile.json";
        private string updateTasklingWithOutNameFile = "UpdateTasklingWithOutTeamFile.json";
        private string appfabricWithOutNameFile = "AppfabricWithOutTeamFile.json";
        private string updatePoolWithOutNameFile = "UpdatePoolWithOutTeamFile.json";
        private string dataBaseWithOutNameFile = "DataBaseWithOutNameFile.json";


        public MassiveTasksService(IMassiveRepository MassiveTaskRepository, IJsonService JsonService, IJiraRepository JiraRepository)
                                   
        {
            _massiveTaskRepository = MassiveTaskRepository;         
            _jsonService = JsonService;
            _jiraRepository = JiraRepository;
        }

        public IEnumerable<TaskModelData> GetTlsListDTO()
        {
            Console.Write("Lista de tareas sin grupo de trabajo en: C:\\TasksFolder\\" + tslWithOutNameFile);
            List<TaskModelData> taskList = (List<TaskModelData>)_massiveTaskRepository.GetTlsExcelData();
            return GetListDTO(taskList,tslWithOutNameFile);          
        }

        public IEnumerable<TaskModelData> GetInstallTasklingListDTO()
        {
            Console.Write("Lista de tareas sin grupo de trabajo en: C:\\TasksFolder\\" + installTasklingWithOutNameFile);
            List<TaskModelData> taskList = (List<TaskModelData>)_massiveTaskRepository.GetInstallTaskLingExcelData();
            return GetListDTO(taskList, installTasklingWithOutNameFile);
        }

        public IEnumerable<TaskModelData> GetUpdateTasklingListDTO()
        {
            Console.Write("Lista de tareas sin grupo de trabajo en: C:\\TasksFolder\\" + updateTasklingWithOutNameFile);
            List<TaskModelData> taskList = (List<TaskModelData>)_massiveTaskRepository.GetUpdateTaskLingExcelData();
            return GetListDTO(taskList, updateTasklingWithOutNameFile);
        }

        public IEnumerable<TaskModelData> GetAppfabricTasklingListDTO()
        {
            Console.Write("Lista de tareas sin grupo de trabajo en: C:\\TasksFolder\\" + appfabricWithOutNameFile);
            List<TaskModelData> taskList = (List<TaskModelData>)_massiveTaskRepository.GetAppfabricExcelData();
            return GetListDTO(taskList, appfabricWithOutNameFile);
        }

        public IEnumerable<TaskModelData> GetUpdatePoolListDTO()
        {
            Console.Write("Lista de tareas sin grupo de trabajo en: C:\\TasksFolder\\" + updatePoolWithOutNameFile);
            List<TaskModelData> taskList = (List<TaskModelData>)_massiveTaskRepository.GetUpdatePoolExcelData();
            return GetListDTO(taskList, updatePoolWithOutNameFile);
        }

        public IEnumerable<TaskModelData> GetDataBaseListDTO()
        {
            Console.Write("Lista de tareas sin grupo de trabajo en: C:\\TasksFolder\\" + dataBaseWithOutNameFile);
            List<TaskModelData> taskList = (List<TaskModelData>)_massiveTaskRepository.GetDataBaseExcelData();
            return GetListDTO(taskList, dataBaseWithOutNameFile);
        }


        public IEnumerable<TaskModelData> GetListDTO(List<TaskModelData> taskList, string withOutNameFile)
        {                      
            List<TaskModelData> listWithOutTeam = new List<TaskModelData>();

            List<string> teamList = _jiraRepository.GetTeamApp(taskList.ToList().Select(o => o.appName).ToList()).ToList();
                             
            for (int x = 0; x < taskList.Count - 1; x++)
            {
                taskList[x].team = teamList[x];
            }

            listWithOutTeam = taskList.Where(o => o.team == "" || o.team==null).ToList();
            listWithOutTeam.ForEach(o => o.team = "Not Found");

            _jsonService.SaveJson(withOutNameFile, listWithOutTeam);

            listWithOutTeam.ForEach(o =>
            {
                taskList.Remove(o);
            });

            AddNoTeamFileFilledIdExist(taskList, withOutNameFile);

            return taskList;
        } 
        
        private List<TaskModelData>  AddNoTeamFileFilledIdExist (List<TaskModelData> taskList, string noTeamNameFile)
        {
            string workSpace = @ConfigurationManager.AppSettings["WorkSpace"];
            string filledNameFile = noTeamNameFile.Replace(".json", "Filled.json");

            if (File.Exists(workSpace + filledNameFile))
            {
                taskList.AddRange(_jsonService.LoadJson<TaskModelData>(filledNameFile));
            }
            return taskList;
        }

    }
}
