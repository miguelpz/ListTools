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
            MassiveTasksService ms = new MassiveTasksService(new TlsRepository(new ExcelIOService()), new JsonService(), new JiraRepository(),new InstallTasklingRepository(new ExcelIOService()));
            //var result = ms.GetTlsListDTO();
            //var jsonToAdd = js.LoadJson<TaskModelData>("TlsWithOutTeamToAdd.json");

            //var resultTls = result.ToList();

            //resultTls.AddRange(jsonToAdd);

            // INSTALL TASKLING SECTION

            var installTasklingResult = ms.GetInstallTasklingListDTO();










            TlsRepository tlsRepo = new TlsRepository(new ExcelIOService());
            JiraRepository jr = new JiraRepository();









            //JsonService js = new JsonService();

            //var filled = (List<TlsTaskModelData>)js.LoadJson<TlsTaskModelData>("filled.json");
            //var add = (List<TlsTaskModelData>)js.LoadJson<TlsTaskModelData>("add.json");
            //var problem = new List<TlsTaskModelData>();


            //filled.ForEach(f =>
            //{
            //    if (add.Where(o => o.key == f.key).Count() == 0)
            //        problem.Add(f);

            //});

            //js.SaveJson("TlsTaskToCheck.json", problem);











        }
    }
}

