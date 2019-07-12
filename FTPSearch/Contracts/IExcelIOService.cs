using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Contracts
{
    public interface IExcelIOService
    {
        IEnumerable<string> GetAllNamesInColumn(string fileName, int sheet, int column, bool hasTitle);
        bool WriteListInColumn(string fileKeyConfig, int sheet, int column, IEnumerable<string> nameList, bool hasTitle);
    }
}
