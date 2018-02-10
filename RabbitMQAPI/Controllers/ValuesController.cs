using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RabbitMQAPI.Services;

namespace RabbitMQAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "RabbitMQ", ".NET Core" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            Send sender = new Send("Rabbit" + DateTime.Now.ToString());
        }
    }
}
