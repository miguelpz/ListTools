using FTPSearch.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.ExcelServices
{
    interface IExcelService
    {
        List<string> ImportExcel();
        void WriteExcel(List<MatchDTO> resultado);
    }
}
