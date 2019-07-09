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
        void SendPost(string json);
        IEnumerable<string> GetTicketReport(IEnumerable<string> tickets);
    }
}
