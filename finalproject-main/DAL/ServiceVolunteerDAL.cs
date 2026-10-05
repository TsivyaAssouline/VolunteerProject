using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceVolunteerDAL
    {
        HelpForElderlyEntities1 db = new HelpForElderlyEntities1();

        public List<ArrangedRequests> GetAllArrangedRequestsWithRelations()
        {
            return db.ArrangedRequests.ToList();
        }
        //2
        public List<VolunteersHaveMostHoursToDonateLeft_Result> VolunteersHaveMostHoursToDonateLeft(int idS)
        {


            return db.VolunteersHaveMostHoursToDonateLeft(idS).ToList();   

        }


    }
}
