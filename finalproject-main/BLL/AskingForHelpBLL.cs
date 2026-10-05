using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AskingForHelpBLL
    {
        AskingForHelpDAL askingForHelpDAL=new AskingForHelpDAL();
        RequestsBLL requestBLL = new RequestsBLL();
        public Dictionary<AskingForHelpDTO, List<RequestsDTO>> getNotConfirmedRequestsForEachAskingForHelp()
        {
            Dictionary<AskingForHelpDTO, List<RequestsDTO>> d = new Dictionary<AskingForHelpDTO, List<RequestsDTO>>();
            List<AskingForHelpDTO> l = GetAskingForHelp();
            foreach (AskingForHelpDTO a in l)
            {
                d.Add(a, (requestBLL.GetOnHoldRequests(a.IdAskingForHelp)));
            }
            return d;
        }
        public AskingForHelpDTO getAskingForHelpWithMostNotConfirmedRequests()
        {
            Dictionary<AskingForHelpDTO, List<RequestsDTO>> d = getNotConfirmedRequestsForEachAskingForHelp();
           return d.FirstOrDefault(x=>x.Value.Count== d.Max(y => y.Value.Count())).Key;       
        }

        public List<AskingForHelpDTO> GetAskingForHelp()
        {
            return CONVERTER.AskingForHelpConverter.ToDTO(askingForHelpDAL.GetAskingForHelp());
        }
    }
}
