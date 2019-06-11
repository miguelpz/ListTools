using FTPSearch.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FTPSearch.RenameServices;

namespace FTPSearch.Contracts
{
    public class RenameExcelService: IRenameExcelService
    {
        private IExcelIOService _excelIOService;

        public RenameExcelService(IExcelIOService ExcelIOService)
        {
            _excelIOService = ExcelIOService;
        }
        
        public bool TrimNugetVersion(int sheet, int column, bool hasTitle)
        {
            var result= _excelIOService.GetAllNamesInColumn(sheet, column, hasTitle).Select(o => o.TrimNugetVersion()).ToList();
            return _excelIOService.WriteListInColumn(sheet, column+1, result, true); 
                   
        }


    }
}
