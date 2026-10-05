using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServicBLL

    {
        ServicDAL servicDAL=new ServicDAL();    
        //1
        public int MonthlyHoursRemaining(string id)
        {
            return servicDAL.MonthlyHoursRemaining(id);
        }
        //3
        public void  NumVolunteersForThisServiceAndApproved(int id, out int volCount, out int approvedRequestsCount)
        {
             servicDAL.NumVolunteersForThisServiceAndApproved(id, out  volCount, out  approvedRequestsCount);    
        }
        //4
        public bool EnoughHoursDonated(int idS)
        {
            return servicDAL.EnoughHoursDonated(idS);   
        }
        //5
        public int howManyUniqueHelpDoVolunteerGive(string id)
        {
            return servicDAL.howManyUniqueHelpDoVolunteerGive(id);
        }
    }
}
