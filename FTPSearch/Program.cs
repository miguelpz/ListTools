using FTPSearch.DTO;
using FTPSearch.Contracts;
using FTPSearch.ExcelServices;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FTPSearch.Services;

namespace FTPSearch
{
    class Program
    {
        static void Main(string[] args)
        {


            ExcelIOService _excelIOService = new ExcelIOService();
            RenameExcelService _renameExcelService = new RenameExcelService(_excelIOService);
            _renameExcelService.TrimNugetVersion(1, 1, true);
            

            
            //ExcelService service = new ExcelService();

            //List<string> users = service.ImportExcel();

            //service.EscribeExcel(users);



            //DirectoryInfo dir = new DirectoryInfo(@ConfigurationManager.AppSettings["RootDirectoryToExplore"]);

            //FileService _fileService = new FileService(dir);

            //var usersList = new ExtractIdsFromFtpFiles(_fileService.GetFtpsFiles(), users).GetAll();

            
            //usersList = new ExtractAppNameFromUsersIds(_fileService.GetIomFiles(), usersList).GetAll();

            //usersList = new GetOwnerFromAppUsers(usersList).GetAll();

            //_fileService.SaveToJson(usersList);

            //service.WriteExcel(usersList);
        }
    }
}