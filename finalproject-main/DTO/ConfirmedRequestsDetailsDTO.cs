using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ConfirmedRequestsDetailsDTO
    {

        public string VolunteerName { get; set; }
        public string AskingForHelpName { get; set; }
        public DateTime DateRequest { get; set; }
        public string requestContent { get; set; }

        public ConfirmedRequestsDetailsDTO() { } 

        public ConfirmedRequestsDetailsDTO(string VolunteerName, string AskingForHelpName, DateTime DateRequest, string requestContent)
        {
            this.VolunteerName = VolunteerName;
            this.requestContent = requestContent;
            this.DateRequest = DateRequest;
            this.AskingForHelpName = AskingForHelpName;
        }
    }
}
