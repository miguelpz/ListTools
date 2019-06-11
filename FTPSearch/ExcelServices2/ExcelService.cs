using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Configuration;
using FTPSearch.DTO;
using System.Text.RegularExpressions;

namespace FTPSearch.ExcelServices
{
    class ExcelService:IExcelService
    {
        ExcelMemoryManager manager = new ExcelMemoryManager();
        public List<string> ImportExcel()
        {
            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(@ConfigurationManager.AppSettings["Excel"]);
            Worksheet xlWorksheet = xlWorkbook.Sheets[8];
            Range xlRange = xlWorksheet.UsedRange;
            var rowCount = xlRange.Rows.Count;
            List<string> resultado = new List<string>();
            for (int i = 1; i <= rowCount-1; i++)
            {

                string appExtract = xlRange.Cells[i, 1].Value2.ToString();
                //if (appExtract.Contains("nupkg"))
                //{
                    var index = Regex.Match(appExtract,".[0-9]");
                    var indice = index.Index;
                    resultado.Add(appExtract.Remove(indice));
                //}
                //else
                //{
                //    resultado.Add("");
                //}


                //resultado.Add(xlRange.Cells[i , 1].Value2.ToString());
                
            }
            manager.MemoryManager(xlApp, xlWorkbook, xlWorksheet, xlRange);
            return resultado;
        }


        public void EscribeExcel (List<string> resultado)
        {
            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(@ConfigurationManager.AppSettings["Excel"]);
            Worksheet xlWorksheet = xlWorkbook.Sheets[8];
            Range xlRange = xlWorksheet.UsedRange;

            int celda = 0;

            foreach (string res in resultado)
            {
                celda++;
                xlRange.Cells[celda, 2].Value2 = res;
            }

            manager.MemoryManager(xlApp, xlWorkbook, xlWorksheet, xlRange);
            xlWorkbook.Save();
            xlApp.Quit();



        }









        public void WriteExcel(List<MatchDTO> resultado)
        {
            List<ExcelList> excelList = new List<ExcelList>();
            
            Application xlApp = new Application();
            Workbook xlWorkbook = xlApp.Workbooks.Open(@ConfigurationManager.AppSettings["Excel"]);
            Worksheet xlWorksheet = xlWorkbook.Sheets[8];
            Range xlRange = xlWorksheet.UsedRange;
            var rowCount = xlRange.Rows.Count;
            for (int i = 1; i <= rowCount - 1; i++)
            {
                if (xlRange.Cells[i, 2] != null && xlRange.Cells[i, 2].Value2 != null)
                {
                    ExcelList auxExcel = new ExcelList();
                    auxExcel.usuario = xlRange.Cells[i + 1, 2].Value2.ToString();
                    auxExcel.celda = i + 1;
                    excelList.Add(auxExcel);
                }
                
            }
             foreach (var aux in excelList)
                {
                foreach (var item in resultado)
                {
                    
                    if (item.user.Equals(aux.usuario))
                    {
                        foreach(var app in item.Application)
                        {
                            xlRange.Cells[aux.celda, 4].Value2 += app + ", ";
                        }

                        

                        foreach (var owner in item.Owner)
                        {
                            xlRange.Cells[aux.celda, 3].Value2 += owner + ", ";
                        }
                    }
                }
             
             }
            //manager.MemoryManager(xlApp, xlWorkbook, xlWorksheet, xlRange);
            xlWorkbook.Save();
            xlApp.Quit();
        }
    }
}
