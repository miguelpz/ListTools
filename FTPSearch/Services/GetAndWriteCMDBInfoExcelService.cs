using FTPSearch.Contracts;
using FTPSearch.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Services
{
    public class GetAndWriteCMDBInfoExcelService
    {
        private readonly IExcelIOService _excelIOService;
        private readonly IJiraRepository _jiraRepository;

        public GetAndWriteCMDBInfoExcelService(IExcelIOService ExcelIOService, IJiraRepository JiraRepository)
        {

            _excelIOService = ExcelIOService;
            _jiraRepository = JiraRepository;
        }

        public bool FillAppNamesExcelFile()
        {
            List<string> team = new List<string>();
            List<string> owner = new List<string>();
            List<string> project = new List<string>();

            try
            {
                IEnumerable<string> appList = _excelIOService.GetAllNamesInColumn("UpdateComponetsExcelFile", 1, 1, false).ToList();


                team = _jiraRepository.GetTeamApp(appList).ToList();
                owner = _jiraRepository.GetOwnerApp(appList).ToList();
                project = _jiraRepository.GetProjectApp(appList).ToList();

                team = team.Select(o => o == "" ? o = "?" : o).ToList();
                owner = owner.Select(o => o == "" ? o = "?" : o).ToList();
                project = project.Select(o => o == "" ? o = "?" : o).ToList();

                _excelIOService.WriteListInColumn("UpdateComponetsExcelFile", 1, 2, team, false);
                _excelIOService.WriteListInColumn("UpdateComponetsExcelFile", 1, 3, project, false);
                _excelIOService.WriteListInColumn("UpdateComponetsExcelFile", 1, 4, owner, false);

                return true;
            }
            catch
            {
                return false;
            }

        }
        
            
        

    }
}
