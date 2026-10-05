using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.CONVERTER
{
    public class VolunteerConverter
    {
        public static VolunteerDTO toDTO(Volunteer v)
        {
            return new VolunteerDTO()
            {
                FullName = v.FullName,
                IdVolunteer = v.IdVolunteer,
                Phone = v.Phone

            };
        }
        public static List<VolunteerDTO> toDTO(List<Volunteer> v)
        {
            return v.Select(toDTO).ToList();
        }
    }
}
