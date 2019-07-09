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
            List<string> name = new List<string>();
            List<string> desctiptionTask = new List<string>();

            ExcelIOService _excelIOService = new ExcelIOService();

            name = _excelIOService.GetAllNamesInColumn(1, 1, false).ToList();
            desctiptionTask = _excelIOService.GetAllNamesInColumn(1, 2, false).ToList();

            List <AutomatizaDTO> tareas= new List<AutomatizaDTO>();

            for (int x =0; x<name.Count; x++)
            {
                tareas.Add(new AutomatizaDTO()
                {
                    appName = name[x],
                    description = desctiptionTask[x]
                });                                      
            }

            var tareasFiltradas = tareas.Where(t => t.appName == "Vueling.Seats.WebUI" || t.appName == "Vueling.OPS.SSO.WebUI").ToList();



            List <TareaDTO> tareasCrear = new List<TareaDTO>();

            tareasFiltradas.ForEach(o => tareasCrear.Add(new TareaDTO(o)));
    
            
            
            var salida = JsonConvert.SerializeObject(tareasCrear);

            Console.Read();








            List<string> result = new List<string>();

            IEnumerable<string> tickets = _excelIOService.GetAllNamesInColumn(1, 6, true);

            foreach (string ticket in tickets)
            {
                if (ticket != "")
                {
                    char character = ticket.ElementAt(ticket.Length-1);
                }

                if (ticket!= "" && ticket.ElementAt(ticket.Length-1) == ',')
                {
                    result.Add(ticket.Remove(ticket.Length-1));
                }
                else
                {
                    result.Add("");
                }              
            }

            _excelIOService.WriteListInColumn(1, 7, result, true);








            //JsonService jsonService = new JsonService();

            //var faltan = jsonService.LoadListJsonFile().ToList(); 



            

            //List<string> totalSoluctions = new List<string>();
            //List<string> totalPrincipal = new List<string>();
            //List<string> totalSecundaria = new List<string>();
            //List<string> totalLineaNuget = new List<string>();
            //List<string> totalLinea = new List<string>();



         

            //totalSoluctions = _excelIOService.GetAllNamesInColumn(1, 2, false).ToList();
            //totalPrincipal = _excelIOService.GetAllNamesInColumn(2, 1, false).ToList();
            //totalSecundaria = _excelIOService.GetAllNamesInColumn(3, 1, false).ToList();
            //totalLineaNuget = _excelIOService.GetAllNamesInColumn(4, 1, false).ToList();
            //totalLinea = _excelIOService.GetAllNamesInColumn(5, 1, false).ToList();


            //List<TslData> tareas = new List<TslData>();

           

            




            //foreach (string soluction in totalSoluctions)
            //{



            //    tareas.Add(new TslData()
            //    {
            //        soluctionName = soluction,
            //        frameworkPrincipal = totalPrincipal.Where(o => o.Contains(soluction)).ToList(),
            //        frameworkSecundaria = totalSecundaria.Where(o => o.Contains(soluction)).ToList(),
            //        codigoNuget = totalLineaNuget.Where(o => o.Contains(soluction)).ToList(),
            //        codigo = totalLinea.Where(o => o.Contains(soluction)).ToList()
            //    });




            //}

            //List<TslData> tareasFiltradas = new List<TslData>();

            //tareas.ForEach(o =>
            //{

            //    if (o.frameworkPrincipal.Count > 0 || o.frameworkPrincipal.Count > 0 || o.codigoNuget.Count > 0 || o.codigo.Count > 0)
            //    {
            //        tareasFiltradas.Add(o);
            //    }


            //});

            //_excelIOService.WriteListInColumn(1, 1, tareasFiltradas.Select(o => o.soluctionName), false);




           // List<TslData> tareasFiltradas2 = new List<TslData>();

           // tareasFiltradas = tareasFiltradas.Where(o => faltan.Contains(o.soluctionName)).ToList();

                
            
            
            



           // int principal = 0;
           // int secundario = 0;
           // int nuget = 0;
           // int linea = 0;



           //tareasFiltradas.ForEach(o => { 


           //    principal += o.frameworkPrincipal.Count();
           //    secundario += o.frameworkSecundaria.Count();
           //    nuget += o.codigoNuget.Count();
           //    linea += o.codigo.Count();


           // });

           // List<TareaDTO> listadoTareas = new List<TareaDTO>();


           // tareasFiltradas.ForEach(o =>
           // {
           //     listadoTareas.Add(new TareaDTO(o));
           // });



            //string salida = JsonConvert.SerializeObject(listadoTareas.Where(o => o.summary.Contains("Anisec.SSO")));
            //string salida = JsonConvert.SerializeObject(listadoTareas);


            //jira.SendPost(salida);

            // Console.Read();


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