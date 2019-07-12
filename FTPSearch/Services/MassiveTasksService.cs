using FTPSearch.Contracts;
using FTPSearch.DTO;
using FTPSearch.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Services
{
    public class MassiveTasksService
    {
        private readonly IMassiveRepository _tlsRepository;
        private readonly IMassiveRepository _installTasklingRepository;

        private readonly IJsonService _jsonService;
        private readonly IJiraRepository _jiraRepository;

        public MassiveTasksService(IMassiveRepository TlsRepository, IJsonService JsonService, IJiraRepository JiraRepository,
                                   IMassiveRepository InstallTasklingRepository)
        {
            _tlsRepository = TlsRepository;
            _installTasklingRepository = InstallTasklingRepository;
            _jsonService = JsonService;
            _jiraRepository = JiraRepository;
        }

        public IEnumerable<TaskModelData> GetTlsListDTO()
        {
            Console.Write("Lista de tareas sin grupo de trabajo en: C:\\TasksFolder\\TlsWithOutTeam.json");

            List<TaskModelData> tlsList = (List<TaskModelData>)_tlsRepository.GetDataExcelFile();
            List<TaskModelData> tslWithOutTeam = new List<TaskModelData>();

            List<string> teamList = _jiraRepository.GetTeamApp(tlsList.ToList().Select(o => o.appName).ToList()).ToList();
            
            var res= teamList.Where(o => o == "").Count();
           
            for (int x = 0; x < tlsList.Count - 1; x++)
            {
                tlsList[x].team = teamList[x];
            }

            tslWithOutTeam = tlsList.Where(o => o.team == "").ToList();
            _jsonService.SaveJson("TlsWithOutTeamFile.json", tslWithOutTeam);

            tslWithOutTeam.ForEach(o =>
            {
                tlsList.Remove(o);
            });

            return tlsList;

        }

        public IEnumerable<TaskModelData> GetInstallTasklingListDTO()
        {
            Console.Write("Lista de tareas sin grupo de trabajo en: C:\\TasksFolder\\TlsWithOutTeam.json");

            List<TaskModelData> taskList = (List<TaskModelData>)_installTasklingRepository.GetDataExcelFile();
            List<TaskModelData> taskOutTeam = new List<TaskModelData>();

            List<string> teamList = _jiraRepository.GetTeamApp(taskList.ToList().Select(o => o.appName).ToList()).ToList();

            var res = teamList.Where(o => o == "").Count();

            for (int x = 0; x < taskList.Count - 1; x++)
            {
                taskList[x].team = teamList[x];
            }

            taskOutTeam = taskList.Where(o => o.team == "").ToList();
            _jsonService.SaveJson("InstallTasklingWithOutTeamFile.json", taskOutTeam);

            taskOutTeam.ForEach(o =>
            {
                taskList.Remove(o);
            });

            return taskList;

        }


    }
}
