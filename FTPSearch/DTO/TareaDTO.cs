using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.DTO
{
    public class TareaDTO
    {
        public string jiraProject { get; set; }
        public string applicationName { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string priority { get; set; }
        public List<string> components { get; set; }
        public List<string> Labels { get; set; }
        public string inWardIssueKey { get; set; }
        public string relation { get; set; }
        public string EpicLink { get; set; }


        





        public TareaDTO()
        {
            components = new List<string>();
            Labels = new List<string>();
            jiraProject = "ITT";
            summary = "Actualizar FrameWork y desabilitar forzado TLS ";
            description = "tarea de prueba";
            type = "Task";
            priority = "High";
            components.Add("TIT_DeudaTecnica_Arquitectura");
            Labels.Add("ITT_seguridad");
            EpicLink = "ITT-474";
        }




        private string SetIntroduction()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Hola, ");
            sb.AppendLine("");
            sb.AppendLine("Desde OSI se solicita que todas las aplicaciones solo permitan conexiones con el protocolo de seguridad TLS 1.2.");
            sb.AppendLine("");
            sb.AppendLine("(Como comentario os informo que hace meses para las aplicaciones que accedían a Navitaire se habilitó por código el TLS 1.2, pero no se bloqueó el 1.0 ni 1.1).");
            sb.AppendLine("");
            sb.AppendLine("También os informo que se ha intentado bloquear los protocolos no seguros a nivel de servidor de forma masiva pero muchas aplicaciones han fallado por no tener habilitado por código el TLS 1.2 (y se tuvo que revertir este cambio en los servidores, exponiéndonos a las vulnerabilidades nuevamente).");
            sb.AppendLine("");
            sb.AppendLine("Revisando el tema con Arquitectura, se ha acordado seguir las recomendaciones oficiales de Microsoft:");
            sb.AppendLine("");
            sb.AppendLine("https://docs.microsoft.com/en-us/dotnet/framework/network-programming/tls");
            sb.AppendLine("");
            sb.AppendLine("Por este motivo os hemos creado una tarea por cada solución afectada en tu producto (según la asignación de la CMDB), para que modifiquéis las aplicaciones que os indicamos abajo.");
            sb.AppendLine("");
            sb.AppendLine("El cambio a realizar a nivel de código es muy simple:");
            sb.AppendLine("");
            sb.AppendLine("Tenéis que buscar la línea de código que contenga \"ServicePointManager.SecurityProtocol\" (normalmente en el global.asax o en el Program.cs, o si es una librería puede que este en otro sitio). Y borrarla. De esta forma no se fuerza el protocolo de seguridad por código y se deja al sistema operativo decidirlo.");
            sb.AppendLine("");
            sb.AppendLine("Para que esto funcione se debe subir de Framework las aplicaciones finales al 4.7.2, y lo que son librerías a 4.6.2.");
            sb.AppendLine("");
            sb.AppendLine("Después tendréis que subir a INT el cambio y revisar que la aplicación levante y no muestre errores de conexiones en el log. Lo mismo en PRE, y finalmente si no se detectan problemas subirlo a PRO y estar atentos que no haya errores en producción para revertirlo rápidamente. Y lo que haya fallado hay que reportarlo, para avisar a dónde nos estemos intentando conectar para que habiliten el TLS 1.2 por su parte.");
            sb.AppendLine("");
            sb.AppendLine("Comentario importante: si la eliminación de la línea con \"ServicePointManager.SecurityProtocol\" lo hacéis en un proyecto que genera NuGet, debéis poneros en contacto con ITT, para ayudaros a detectar todas las aplicaciones que tengan vuestro NuGet instalado y solicitar la tarea para que se actualicen de versión. (si solo hacéis el upgrade de framework no es necesario la actualización del NuGet en quien os usa).");
            sb.AppendLine("");
            sb.AppendLine("Para facilitaros el análisis os pasamos los proyectos afectados de vuestra solución que hemos detectado desde ITT:");
            sb.AppendLine("");

            return sb.ToString();
        }

        private string SetDescription(TslData tslData)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(SetIntroduction());
            sb.AppendLine("");
            sb.AppendLine("==============================================================================================================");
            sb.AppendLine("");
            sb.AppendLine("Solución afectada: " + tslData.soluctionName);

            if (tslData.frameworkPrincipal.Count > 0)
            {
                sb.AppendLine("");
                sb.AppendLine("Actualizar a FrameWork 4.7.2: ");
                sb.AppendLine("");
                tslData.frameworkPrincipal.ForEach(o => sb.AppendLine("    " + o));
            }
            if (tslData.frameworkSecundaria.Count > 0)
            {
                sb.AppendLine("");
                sb.AppendLine("Actualizar a FrameWork 4.6.2: ");
                sb.AppendLine("");
                tslData.frameworkSecundaria.ForEach(o => sb.AppendLine("    " + o));
            }
            if (tslData.codigoNuget.Count > 0)
            {
                sb.AppendLine("");
                sb.AppendLine("Borrar linea de codigo en los siguientes proyectos que generan nugets: ");
                sb.AppendLine("");
                tslData.codigoNuget.ForEach(o => sb.AppendLine("    " + o));
            }
            if (tslData.codigo.Count > 0)
            {
                sb.AppendLine("");
                sb.AppendLine("Borrar linea de codigo en los siguientes proyectos: ");
                sb.AppendLine("");
                tslData.codigo.ForEach(o => sb.AppendLine("    " + o));

            }

               
            return sb.ToString();

            
        }



    }
}
