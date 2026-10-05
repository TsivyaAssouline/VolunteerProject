using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CONVERTER
{

        public static class NextVolunteeringDetailsConverter
        {
            public static NextVolunteeringDetailsDTO ConvertToDTO(getNextVolunteeringDetails_Result entity)
            {
             

                return new NextVolunteeringDetailsDTO
                {
                    FullName = entity.FullName,
                    Phone = entity.Phone,
                    Address = entity.Adress, 
                    NameService = entity.NameService,
                    RequestContent = entity.RequestContent,
                    DateRequest = entity.DateRequest
                };
            }

            public static List<NextVolunteeringDetailsDTO> ConvertToDTO(List<getNextVolunteeringDetails_Result> entities)
            {

                return entities.Select(ConvertToDTO).ToList();
            }
        }
}
