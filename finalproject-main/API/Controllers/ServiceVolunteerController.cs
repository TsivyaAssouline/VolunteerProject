using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ServiceVolunteerController : ApiController
    {
        ServiceVolunteerBLL serviceVolunteerBLL=new ServiceVolunteerBLL();

        [Route("api/ServiceVolunteer/GetTopPersonRequestsByVolunteer/{id}"), HttpGet]
        public IHttpActionResult GetTopPersonRequestsByVolunteer(string id)
        {
            if (id.Length!=9)
            {
                return BadRequest("Volunteer ID is required.");
            }

            var result = serviceVolunteerBLL.GetTopPersonRequestsByVolunteer(id);

            if (result.Count == 0)
            {
                return NotFound(); // לא נמצאו בקשות עבור מתנדב זה
            }

            return Ok(result);
        }

        
    }
}
