using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.ExcelServices
{
    interface IExcelMemoryManager
    {
        void MemoryManager(Application xlApp, Workbook xlWorkbook, Worksheet xlWorksheet, Range xlRange);
    }
}
