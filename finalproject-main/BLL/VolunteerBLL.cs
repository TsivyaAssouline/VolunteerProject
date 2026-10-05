using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class VolunteerBLL
    {
        VolunteerDAL VolunteerDAL = new VolunteerDAL();

        //7
        public void GetVolunteerHoursInfo(string id ,out int hoursthismonth, out double averagethismonth)
        {
             VolunteerDAL.GetVolunteerHoursInfo(id, out  hoursthismonth, out averagethismonth);

        }
    }
}
