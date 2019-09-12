using FTPSearch.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Repositories
{
    public interface IJiraRepository
    {
        string GetOwnerFromApp(string app);

        void CreateTask(IEnumerable<TareaDTO> tasksToCreate);
        IEnumerable<string> GetTicketReport(IEnumerable<string> tickets);
        IEnumerable<string> GetProductApp(IEnumerable<string> appNames);
        IEnumerable<string> GetOwnerApp(IEnumerable<string> appNames);
        IEnumerable<string> GetProjectApp(IEnumerable<string> appNames);
        IEnumerable<string> GetTeamApp(IEnumerable<string> appNames);
    }
}
