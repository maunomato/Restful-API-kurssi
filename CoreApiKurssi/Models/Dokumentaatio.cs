using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApiKurssi.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class Dokumentaatio : ControllerBase
    {
        documentationContext dc = new documentationContext();

        // GET: api/<Dokumentaatio>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Dokumentaatio>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Dokumentaatio>
        [HttpPost]
        public void Post([FromBody] Documentation value)
        {
            dc.Documentations.Add(value);
            dc.SaveChanges();
        }

        // PUT api/<Dokumentaatio>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Dokumentaatio>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
