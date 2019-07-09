
using FTPSearch.Contracts;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FTPSearch.Services
{
    public class ExcelIOService : IExcelIOService
    {
        public IEnumerable<string> GetAllNamesInColumn(int sheet, int column, bool hasTitle)
        {
            List<string> nameList = new List<string>();

            string filePath = ConfigurationManager.AppSettings["Excel"];
            Application xlApp = new Application();
            Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
            Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(sheet);

            Range xlRange = xlWorkSheet.UsedRange;
            int totalRows = xlRange.Rows.Count;
            int totalColumns = xlRange.Columns.Count;

            int initRow = 1;

            if (hasTitle)
            {
                initRow = 2;
            }

            for (int rowCount = initRow; rowCount <= totalRows; rowCount++)
            {
                nameList.Add(Convert.ToString((xlRange.Cells[rowCount, column] as Range).Text));                 
            }

            xlWorkBook.Close();
            xlApp.Quit();

            return nameList;
        }


        public bool WriteListInColumn(int sheet,int column, IEnumerable<string> nameList,int sinceRow, bool hasTitle)
        {
            string filePath = ConfigurationManager.AppSettings["ExcelWriteFile"];

            Application xlApp = new Application();
            object misValue = System.Reflection.Missing.Value;

            Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
            Worksheet xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int initRow = sinceRow;

            if (hasTitle)
            {
                initRow++;
            }


            foreach (string name in nameList)
            {
                initRow++;
                xlWorkSheet.Cells[initRow, column] = name;
            }

            try
            {
                xlWorkBook.Save();
                xlWorkBook.Close();
                xlApp.Quit();
            }
            catch
            {
                return false;
            }

            return true;
        }



        public bool WriteListInColumn(int sheet, int column, IEnumerable<string> nameList, bool hasTitle)
        {

            //if (!IsColumEmpty(sheet,column))
            //{
            //    throw new Exception("Column aren't Empty!");
            //}

            string filePath = ConfigurationManager.AppSettings["ExcelWriteFile"];

            Application xlApp = new Application();
            object misValue = System.Reflection.Missing.Value;

            Workbook xlWorkBook = xlApp.Workbooks.Open(filePath);
            Worksheet xlWorkSheet =( Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int initRow = 0;

            if (hasTitle)
            {
                initRow = 1;
            }


            foreach(string name in nameList)
            {
                initRow++;                
                xlWorkSheet.Cells[initRow, column] = name;                
            }

            try
            {
                xlWorkBook.Save();
                xlWorkBook.Close();
                xlApp.Quit();
            }
            catch
            {
                return false;
            }

            return true;
            
        }

       

        private bool IsColumEmpty(int sheet, int column)
        {
            bool result = true;

            if (GetAllNamesInColumn(sheet, column, true).Where(name => name.Length > 0).Count() > 0)
            {
                return false;
            }                            
            return result;                             
        }
    }
}
