using System;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace FTPSearch.ExcelServices
{
    class ExcelMemoryManager : IExcelMemoryManager
    {
        public void MemoryManager(Application xlApp, Workbook xlWorkbook, Worksheet xlWorksheet, Range xlRange)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
    }
}
