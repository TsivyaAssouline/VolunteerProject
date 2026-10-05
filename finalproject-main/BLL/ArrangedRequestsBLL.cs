using BLL.CONVERTER;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ArrangedRequestsBLL
    {
        ArrangedRequestsDAL arrangedRequestsDAL=new ArrangedRequestsDAL();
        public List<ArrangedRequestsDTO> getArrangedRequestOfVolunteer(string id)
        {
            return CONVERTER.ArrangedRequestsConverter.ToDTO( arrangedRequestsDAL.GetArrangedRequests().FindAll(x => x.IdVolunteer == id));
        }
        public List<ArrangedRequestsDTO> GetArrangedRequests()
        {
           return CONVERTER.ArrangedRequestsConverter.ToDTO( arrangedRequestsDAL.GetArrangedRequests());
        }
        public List<ConfirmedRequestsDetailsDTO> GetConfirmedRequestsDetails()
        {
            List < ConfirmedRequestsDetailsDTO >l= new List < ConfirmedRequestsDetailsDTO >();
            foreach (ArrangedRequests req in arrangedRequestsDAL.GetArrangedRequests()) {
                l.Add(new ConfirmedRequestsDetailsDTO(req.Volunteer.FullName, req.Requests.AskingForHelp.FullName, req.Requests.DateRequest, req.Requests.RequestContent));
            }
            return l;
        }
        //6
        public List< NextVolunteeringDetailsDTO> getNextVolunteeringDetails(string id)
        {
            return CONVERTER.NextVolunteeringDetailsConverter.ConvertToDTO(arrangedRequestsDAL.getNextVolunteeringDetails(id));
        }

    }
}
