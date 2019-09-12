using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.DTO
{
    public class TaskTaskLingModel:TaskJiraModelBase
    {

        public TaskTaskLingModel(string appname)
        {
            List<string>  ComponentList = new List<string>();
            List<string>  LabelList = new List<string>();


            JiraProject = "ITT";
            Summary = "Instalar Taskling en " + appname;
            Description = setInstallTaskLingDescription();
            Type = "Task";
            Priority = "Low";
            ComponentList.Add("TIT_DeudaTecnica_Arquitectura");
            LabelList.Add("ITT");
            Components = ComponentList.ToList();
            Labels = LabelList.ToList();
        }

        private string setInstallTaskLingDescription()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Se ha detectado que esta aplicación utiliza un Runbook sin tener instalado Tasklin. Se necesitará Instalar la última versión de Taskling:");
            sb.AppendLine("");
            sb.AppendLine("https://wiki.vueling.com/display/IT/ATC.Taskling.Client");
            sb.AppendLine("");
            sb.AppendLine("Para cualquier duda preguntar al grupo de ITT o a Arquitectura");

            return sb.ToString();
        }


    }
}
