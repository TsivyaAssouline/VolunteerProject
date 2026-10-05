using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CONVERTER
{
    public  class ArrangedRequestsConverter
    {
        public static ArrangedRequestsDTO ToDTO(ArrangedRequests a)
        {
            return new ArrangedRequestsDTO()
            {
                IdArrangedRequests = a.IdArrangedRequests,
                IdRequest = a.IdRequest,
                IdVolunteer = a.IdVolunteer,

            };
        }
        public static List<ArrangedRequestsDTO> ToDTO(List<ArrangedRequests> a)
        {
            return a.Select(x => ToDTO(x)).ToList();
        }

    }
}
