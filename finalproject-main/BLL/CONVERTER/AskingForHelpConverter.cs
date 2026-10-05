using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CONVERTER
{
    public static class AskingForHelpConverter
    {
        public static AskingForHelpDTO ToDTO(AskingForHelp afh)
        {
            return new AskingForHelpDTO()
            {
                Adress = afh.Adress,
                FullName = afh.FullName,
                IdAskingForHelp = afh.IdAskingForHelp,
                Phone = afh.Phone
            };
        }
        public static List<AskingForHelpDTO> ToDTO(List<AskingForHelp> afh)
        {
            return afh.Select(a => ToDTO(a)).ToList();
        }

    }
}
