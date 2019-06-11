using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.Contracts
{
    public interface IRenameExcelService
    {
        bool TrimNugetVersion(int sheet, int column, bool hasTitle);
    }
}
