using CoreApiKurssi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiKurssi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Harjoitus2Controller : ControllerBase
    {
        private northwindContext nwc = new northwindContext();
        public string Get() => "Harjoitukset #2";

        [HttpGet]
        [Route("asiakas/{id}")]
        public Customer Asiakas(string id) {
            if (id != null)
            {
                var c = nwc.Customers.First(c => c.CustomerId.Contains(id));
                if (c == null) return null;
                return c;
            }
            return null;
        }

        [HttpGet]
        [Route("asiakkaat")]
        public IEnumerable<Customer> Asiakkaat()
        {
            var lc = from cust in nwc.Customers select cust;
            return lc.ToArray();
        }
    }
}
