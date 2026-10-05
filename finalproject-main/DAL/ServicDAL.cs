using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServicDAL
    {
        HelpForElderlyEntities1 db = new HelpForElderlyEntities1();
        //5
        public int howManyUniqueHelpDoVolunteerGive(string id)
        {
            var idV = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = System.Data.SqlDbType.NChar,
                Size = 9,
                Value = id,
            };
          
            return db.Database.SqlQuery<int>("SELECT dbo.howManyUniqueHelpDoVolunteerGive(@id)", idV).FirstOrDefault();

        }

        //1
        public int MonthlyHoursRemaining(string id)
        {
            var idS = new SqlParameter
            {
                ParameterName = "@idVolunteer",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = id,
            };

            var result = db.Database.SqlQuery<int>("SELECT dbo.MonthlyHoursRemaining(@idVolunteer)", idS).FirstOrDefault();

            return result;
        }

        //3
        public void NumVolunteersForThisServiceAndApproved(int id, out int volCount, out int approvedRequestsCount)
        {
            var idS = new SqlParameter
            {
                ParameterName = "@idService",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = id,
            };
            var VolCnt = new SqlParameter
            {
                ParameterName = "@VolunteersCount",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
            var ApprovedRequestsCnt = new SqlParameter
            {
                ParameterName = "@ApprovedRequestsCount",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };

           db.Database.SqlQuery<object>("EXEC NumVolunteersForThisServiceAndApproved @idService, @VolunteersCount OUTPUT, @ApprovedRequestsCount OUTPUT", idS, VolCnt, ApprovedRequestsCnt).ToList();
            volCount =Convert.ToInt32( VolCnt.Value);
            approvedRequestsCount = Convert.ToInt32(ApprovedRequestsCnt.Value);
        }

        //4
        public bool EnoughHoursDonated(int idS)
        {
            var idService = new SqlParameter
            {
                ParameterName = "@IdService",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = idS,
            };

            var result = db.Database.SqlQuery<bool>("SELECT dbo.EnoughHoursDonated(@IdService)", idService).FirstOrDefault();

            return result;
        }




    }



}
