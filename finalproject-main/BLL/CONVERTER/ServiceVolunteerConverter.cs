using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CONVERTER
{
    public  class ServiceVolunteerConverter
    {
        public ServiceVolunteerDTO ToDTO(ServiceVolunteer sv) {
            return new ServiceVolunteerDTO()
            {
                IdVolunteer = sv.IdVolunteer,
                HoursVolunteerForMonth = sv.HoursVolunteerForMonth,
                IdService = sv.IdService,
                IdServiceVolunteer = sv.IdServiceVolunteer
            };
        }
        public List<ServiceVolunteerDTO> ToDTO(List<ServiceVolunteer> sv)
        {
            return sv.Select(ToDTO).ToList();
        }
    }
}