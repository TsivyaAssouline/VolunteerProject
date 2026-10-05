using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RequestsBLL
    {
        RequestsDAL RequestsDAL=new RequestsDAL();

        public List<RequestsDTO> GetRequests()
        { return CONVERTER.RequestsConverter.toDTO( RequestsDAL.GetRequests()); }
        public List<RequestsDTO> GetOnHoldRequests(string id)
        { return  GetRequests().FindAll(x =>x.IdAskingForHelp==id&& x.StatusRequest.Trim() == "on hold"); }


        // צרי פונקצייה שתחזיר עבור כול כתובת את רשימת המתנדבים שהולכים 
        //להתנדב בה בחודש הקרוב
        public Dictionary<string, List<VolunteerDTO>> GetVolunteersByAddressForNextMonth()
        {
            var allArrangedRequests = RequestsDAL.GetArrangedRequests();

            DateTime today = DateTime.Today;
            DateTime nextMonth = today.AddMonths(1);

            return allArrangedRequests
                .Where(r => r.Requests.DateRequest >= today && r.Requests.DateRequest <= nextMonth)
                .GroupBy(r => r.Requests.AskingForHelp.Adress)
                .ToDictionary(
                    g => g.Key,
                    g => CONVERTER.VolunteerConverter.toDTO(g.Select(r => r.Volunteer).Distinct().ToList())
                );
        }
  




    }


}
