using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VolunteerDAL
    {
        HelpForElderlyEntities1 db =new HelpForElderlyEntities1();
        public List<Volunteer> getVolunteers()
        {
            return db.Volunteer.ToList();
        }
        //7
        public void GetVolunteerHoursInfo(string id, out int hoursthismonth, out double averagethismonth)
        {
            var idV = new SqlParameter
            {
                ParameterName = "@IdVolunteer",
                SqlDbType = SqlDbType.NChar,
                Size = 9,
                Value = id
            };

            var HoursThisMonthf = new SqlParameter
            {
                ParameterName = "@HoursThisMonth", 
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var AverageLastMonthf = new SqlParameter
            {
                ParameterName = "@AverageLastMonth",
                SqlDbType = SqlDbType.Float, 
                Direction = ParameterDirection.Output
            };

            db.Database.ExecuteSqlCommand(
                "EXEC GetVolunteerHoursInfo @IdVolunteer, @HoursThisMonth OUTPUT, @AverageLastMonth OUTPUT",
                idV, HoursThisMonthf, AverageLastMonthf);

            hoursthismonth = Convert.ToInt32(HoursThisMonthf.Value);
            averagethismonth = Convert.ToDouble(AverageLastMonthf.Value);
        }

    }
}
