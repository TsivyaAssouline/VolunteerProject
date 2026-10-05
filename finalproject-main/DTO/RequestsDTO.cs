using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RequestsDTO
    {
        public int IdRequest { get; set; }
        public string IdAskingForHelp { get; set; }
        public string RequestContent { get; set; }
        public string StatusRequest { get; set; }
        public System.DateTime DateRequest { get; set; }
        public int IdService { get; set; }
        public int NumHours { get; set; }

    }
}
