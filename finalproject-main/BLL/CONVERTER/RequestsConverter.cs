using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CONVERTER
{
    public class RequestsConverter
    {
        public static RequestsDTO toDTO(Requests r)
        {
            return new RequestsDTO()
            {
                IdService = r.IdService,
                DateRequest = r.DateRequest,
                IdAskingForHelp = r.IdAskingForHelp,
                NumHours = r.NumHours,
                IdRequest = r.IdRequest,
                RequestContent = r.RequestContent,
                StatusRequest = r.StatusRequest
            };
        }
        public static List<RequestsDTO>toDTO(List<Requests> r)
        {
            return r.Select(toDTO).ToList();
        }

    }
}
