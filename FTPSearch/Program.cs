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
using FTPSearch.Repositories;
using Newtonsoft.Json.Linq;

namespace FTPSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            // TSL SECTION

            JsonService js = new JsonService();
            MassiveTasksService ms = new MassiveTasksService(new MassiveTaskRepository(new ExcelIOService()), new JsonService(), new JiraRepository());
            MassiveTasksQueryResultsService mtqr = new MassiveTasksQueryResultsService();



            var dataBaseResult = (List<TaskModelData>)ms.GetDataBaseListDTO(); ;
            var updatePoolResult = (List<TaskModelData>)ms.GetUpdatePoolListDTO();
            var appfabricResult = (List<TaskModelData>)ms.GetAppfabricTasklingListDTO();
            var updateTaskLingResult = (List<TaskModelData>)ms.GetUpdateTasklingListDTO();
            var tlsResult = (List<TaskModelData>)ms.GetTlsListDTO();
            var installTaskLingResult = (List<TaskModelData>)ms.GetInstallTasklingListDTO();
        
            mtqr.AddFoundTeamList(dataBaseResult);
            mtqr.AddFoundTeamList(updatePoolResult);
            mtqr.AddFoundTeamList(appfabricResult);
            mtqr.AddFoundTeamList(updateTaskLingResult);
            mtqr.AddFoundTeamList(tlsResult);
            mtqr.AddFoundTeamList(installTaskLingResult);


            var res = mtqr.GetAllTeams();
            




            













        }
    }
}

