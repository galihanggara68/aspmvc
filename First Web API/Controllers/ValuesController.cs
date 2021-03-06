﻿using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace First_Web_API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("person")]
        public Person GetPerson()
        {
            Person person = new Person() { Id = 0, Name = "Ucup", Address = "Bandung" };
            return person;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("getcount")]
        public int GetCount()
        {
            return 10;
        }

        [Route("getdata")]
        public HttpResponseMessage GetData()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Content = new StringContent("Hello");
            return response;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
