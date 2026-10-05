using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class RequestsController : ApiController
    {
        RequestsBLL requestsBLL = new RequestsBLL();
    
           
        
        
        [Route("api/Requests/GetVolunteersByAddressForNextMonth"), HttpGet]
        public IHttpActionResult GetVolunteersByAddressForNextMonth()
        {

            var result = requestsBLL.GetVolunteersByAddressForNextMonth();

            if (result.Count == 0)
            {
                return NotFound(); 
            }

            return Ok(result);
        }

    }} 

