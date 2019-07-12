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
        private readonly ITlsRepository _tlsRepository;
        private readonly IJsonService _jsonService;
        private readonly IJiraRepository _jiraRepository;

        public MassiveTasksService(ITlsRepository TlsRepository, IJsonService JsonService, IJiraRepository JiraRepository)
        {
            _tlsRepository = TlsRepository;
            _jsonService = JsonService;
            _jiraRepository = JiraRepository;
        }

        public IEnumerable<TlsTaskModelData> GetTlsListDTO()
        {
            Console.Write("Lista de tareas sin grupo de trabajo en: C:\\TasksFolder\\TlsWithOutTeam.json");

            List<TlsTaskModelData> tlsList = (List<TlsTaskModelData>)_tlsRepository.GetDataExcelFile();
            List<TlsTaskModelData> tslWithOutTeam = new List<TlsTaskModelData>();

            List<string> teamList = _jiraRepository.GetTeamApp(tlsList.ToList().Select(o => o.appName).ToList()).ToList();
            List<string> teamList2 = _jiraRepository.GetProductApp(tlsList.ToList().Select(o => o.appName).ToList()).ToList();

            var res= teamList.Where(o => o == "").Count();
            var res2= teamList2.Where(o => o == "").Count();


            for (int x = 0; x < tlsList.Count - 1; x++)
            {
                tlsList[x].team = teamList[x];
            }

            tslWithOutTeam = tlsList.Where(o => o.team == "").ToList();
            _jsonService.SaveToJson("JsonTlsWithOutTeamFile", tslWithOutTeam);

            tslWithOutTeam.ForEach(o =>
            {
                tlsList.Remove(o);
            });

            return tlsList;

        }

       
    }
}
