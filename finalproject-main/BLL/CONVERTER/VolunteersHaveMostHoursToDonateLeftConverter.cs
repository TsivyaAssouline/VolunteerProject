using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CONVERTER
{
    public class VolunteersHaveMostHoursToDonateLeftConverter
    {
        public static VolunteerDTO toDTO(VolunteersHaveMostHoursToDonateLeft_Result v)
        {
            return new VolunteerDTO()
            {
                FullName = v.FullName,
                IdVolunteer = v.IdVolunteer,
                Phone = v.Phone

            };
        }
        public static List<VolunteerDTO> toDTO(List<VolunteersHaveMostHoursToDonateLeft_Result> v)
        {
            return v.Select(toDTO).ToList();
        }
    }
}
