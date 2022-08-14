﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Superliga.Logic;

namespace Superliga.Controllers
{
    public class PartnersController : ApiController
    {
        public PartnerLogic partnerlogic = new PartnerLogic();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        
        [Route("api/Partners/List")]
        [HttpGet]
        public string GetList()
        {
            return partnerlogic.getSring();
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}