using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Superliga.Entities;
using Superliga.Logic;
using Superliga.ModelsResponse;

namespace Superliga.Controllers
{
    public class PartnersController : ApiController
    {
        public PartnerLogic pl = new PartnerLogic();

        [Route("api/Partners/records")]
        [HttpGet]
        public int GetRecords()=> pl.CountRecords();

        [Route("api/Partners/ageAverage")]
        [HttpGet]
        public int GetAgeAverage()=> pl.GetAgeAverage();
        
        [Route("api/Partners/list")]
        [HttpGet]
        public List<PartnerDto> GetTopOneHundred()=> pl.GetTopOneHundred();

        [Route("api/Partners/topFive")]
        [HttpGet]
        public List<string> GetTopFiveNames()=> pl.GetTopFiveNames();

        [Route("api/Partners/infoTeams")]
        [HttpGet]
        public List<TeamsDto> GetTeamsInfo() => pl.GetTeamsInfo();

 
    }
}
