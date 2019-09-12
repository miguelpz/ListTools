using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.DTO
{
    
        public class TicketDTO
        {

            public TicketDTO()
            {
                Summary = "Pruebaaaa";
            }
            /// <summary>
            /// Project key to assign ticket. 
            /// If JiraProject propertie is empty, it will assign the JiraProject based on
            /// the aplication name propertie
            /// </summary>
            public string JiraProject { get; set; }

            /// <summary>
            /// Application related to the ticket. if JiraProject is empty, this propertie
            /// will be use to search the JiraProject into Insight CMBD.
            /// </summary>
            public string ApplicationName { get; set; }

            /// <summary>
            /// Sort description of the ticket (this will be shown as title)
            /// </summary>
            public string Summary { get; set; }

            /// <summary>
            /// Explanantion of what is the ticket about
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Sets the type of the ticket. 
            /// Values: Task, Issue and Request
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// Sets the priority. 
            /// Values: Low, Medium, High, Critical
            /// </summary>
            public string Priority { get; set; }

            /// <summary>
            /// Sub-section of a project. It's specific of each project.
            /// Note that a non-existing component can cause a Exception during the execution.
            /// Allows null or empty list.
            /// </summary>
            public IEnumerable<string> Components { get; set; }

            /// <summary>
            /// Categorization of a ticket.
            /// Note that a non-existing component can cause a Exception during the execution.
            /// Allows null or empty list.
            /// </summary>
            public IEnumerable<string> Labels { get; set; }

            /// <summary>
            /// Key of the Ticket related if some
            /// </summary>
            public string InWardIssueKey { get; set; }

            /// <summary>
            /// Type of relation between InWardIssueKey and actual ticket
            /// </summary>
            public string Relation { get; set; }

            /// <summary>
            /// File parse to byte. Max. size = 20MB ~ 20971520 bytes  
            ///</summary>
            public byte[] FileStream { get; set; }

            /// <summary>
            /// Attach file name
            /// </summary>
            public string FileName { get; set; }

        }
    }

