using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class ServiceVolunteerBLL
    {
        
        RequestsDAL requestsDAL = new RequestsDAL();    
        ArrangedRequestsDAL arrangedRequestsDAL = new ArrangedRequestsDAL(); 
        ServiceVolunteerDAL serviceVolunteerDAL = new ServiceVolunteerDAL();
        public List<RequestsDTO> GetTopPersonRequestsByVolunteer(string idVolunteer)
        {
            //prendre les donnees
            
            var arranged=arrangedRequestsDAL.GetArrangedRequests(); 
            
            //on filtre selon les volontaires
            var arrangedForVolunteer=arranged.Where(a=>a.IdVolunteer==idVolunteer).ToList();

            //on compte cb de fois il a aide a chaque personne qui a dmd de l aide
            var helpedCount = arrangedForVolunteer.
                Select(ar=>ar.Requests.AskingForHelp).//grace a la propriete virtual
                GroupBy(p=>p.IdAskingForHelp).
                Select(g => new {Person=g.First(), Count=g.Count()}).
                OrderByDescending(g => g.Count).FirstOrDefault();//ce qu il trouve en premier de ce que y a (cad qui rep a la condition)
            if (helpedCount == null)
            {
                return new List<RequestsDTO>();
            }
            var targetPerson = helpedCount.Person;

            //rend les dmd d un crtn volontaire pour un crtn demandeur d aide
            var requests =arrangedForVolunteer.
                Where(r=>r.Requests.IdAskingForHelp == targetPerson.IdAskingForHelp). 
                Select(ar=>ar.Requests).
                OrderBy(r=>r.DateRequest).                
                Select(r=>new RequestsDTO
            {
                IdRequest = r.IdRequest,
                RequestContent = r.RequestContent,
                DateRequest = r.DateRequest,
                StatusRequest = r.StatusRequest,
                NumHours = r.NumHours
            }).ToList();
            return requests;
        }
        //צרי פונקצייה שתחזיר לכול מתנדב את רשימת הבקשות הקרובות שלו. 
        //מייני לפי שמות המתנדבים.
        public Dictionary<string, List<RequestsDTO>> GetUpcomingRequestsGroupedByVolunteer()
        {
            var arrangedList = serviceVolunteerDAL.GetAllArrangedRequestsWithRelations();
            //dmd a venir
            var grouped = arrangedList
                .Where(ar => ar.Requests != null && ar.Volunteer != null && ar.Requests.DateRequest >= DateTime.Now)
                .GroupBy(ar => ar.Volunteer.FullName)
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(ar => new RequestsDTO
                    {
                        IdRequest = ar.Requests.IdRequest,
                        RequestContent = ar.Requests.RequestContent,
                        DateRequest = ar.Requests.DateRequest,
                        StatusRequest = ar.Requests.StatusRequest,
                        NumHours = ar.Requests.NumHours
                    }).ToList()
                );

            return grouped;
        }
        //2
        public List<VolunteerDTO> VolunteersHaveMostHoursToDonateLeft(int idS)
        {
                return CONVERTER.VolunteersHaveMostHoursToDonateLeftConverter.toDTO( serviceVolunteerDAL.VolunteersHaveMostHoursToDonateLeft(idS));
        }

    }
}
