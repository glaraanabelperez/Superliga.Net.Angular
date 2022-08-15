using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Superliga.Entities;
using Superliga.Logic;
using Superliga.ModelsResponse;
using System.Web.Http.Cors;


namespace Superliga.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PartnersController : ApiController
    {
        public PartnerLogic pl = new PartnerLogic();

        [Route("api/Partners/records")]
        [HttpGet]
        public int GetRecords() => pl.CountRecords();

        [Route("api/Partners/ageAverage")]
        [HttpGet]
        public IHttpActionResult GetAgeAverage() {

            try
            {
                return Ok(pl.GetAgeAverage());
            }
            catch (FormatException e)
            {
                return Content(HttpStatusCode.NoContent, e.Message);
            }
        } 
        
        [Route("api/Partners/list")]
        [HttpGet]
        public List<PartnerDto> GetTopOneHundred()=> pl.GetTopOneHundred();

        [Route("api/Partners/topFive")]
        [HttpGet]
        public List<string> GetTopFiveNames()=> pl.GetTopFiveNames();

        [Route("api/Partners/infoTeams")]
        [HttpGet]
        public IHttpActionResult GetTeamsInfo()
        {
            try
            {
                return Ok(pl.GetTeamsInfo());
            }
            catch (FormatException e)
            {
                return Content(HttpStatusCode.NoContent, e.Message);
            }
        } 

 
    }
}
