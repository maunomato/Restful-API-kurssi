using CoreApiKurssi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiKurssi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AsiakkaatController : Controller
    {
        //onko parempi tässä vai metodien sisällä? emt
        northwindContext nc = new northwindContext();
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var asiakkaat = from a in nc.Customers select a;
            return asiakkaat.ToArray();
        }

        [HttpGet("{key}")]
        public Object GetCustomer(string key)
        {
            var asiakas = nc.Customers.Find(key);
            if(asiakas != null)
            {
                return asiakas;
            }
            return new { Error = "No record found" };
        }

        [HttpPost]
        public Object PostCustomer([FromBody] Customer customerData) {
            //validointi?
            nc.Customers.Add(customerData);
            nc.SaveChanges();
            return new { customerId = customerData.CustomerId };
        }
        
    }
}
