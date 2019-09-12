using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPSearch.DTO
{
    public class TicketResponseDTO
    {      
        public string TicketKey { get; set; }    
        public string Summary { get; set; }     
        public string ErrorMessage { get; set; }      
        public bool HasError => !string.IsNullOrEmpty(ErrorMessage);
    }
}
