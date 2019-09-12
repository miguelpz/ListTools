using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.DTO
{
    public abstract class TaskJiraModelBase
    {
        protected string JiraProject { get; set; }
        protected string ApplicationName { get; set; }
        protected string Summary { get; set; }
        protected string Description { get; set; }
        protected string Type { get; set; }
        protected string Priority { get; set; }
        protected IEnumerable<string> Components { get; set; }
        protected IEnumerable<string> Labels { get; set; }
        protected string InWardIssueKey { get; set; }
        protected string Relation { get; set; }
        protected byte[] Filestream { get; set; }
        protected string FileName { get; set; }
    }
}
