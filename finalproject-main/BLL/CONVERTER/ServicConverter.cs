using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CONVERTER
{
    public class ServicConverter
    {
        public static ServicDTO toDTO(Servic sc)
        {
            return new ServicDTO()
            {
                IdService = sc.IdService,
                NameService = sc.NameService
            };
        }
        public static List<ServicDTO>toDTO(List<Servic> sc)
        {
            return sc.Select(toDTO).ToList();   
        }

    }
}
