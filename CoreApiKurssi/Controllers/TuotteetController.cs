using CoreApiKurssi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiKurssi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TuotteetController : Controller
    {
        northwindContext nc = new northwindContext();

        [HttpGet]
        public IEnumerable<Product> Get() => (from a in nc.Products select a).ToArray();


        [HttpGet("{key}")]
        public Object Get(int key)
        {
            var prod = nc.Products.Find(key);
            if (prod != null) return prod;
            return new { Error = "No record found" };
        }
        [HttpGet]
        [Route("Nimi/{str}")]
        public IEnumerable<Object> GetProductsByNimi(string str)
        {
            var prod = nc.Products.Where(p => p.ProductName.Contains(str));
            if (prod is null)  return new Object[] { new { Error = "Yhtään tuotetta ei löytynyt." } };
            return prod.ToArray();
        }
        [HttpPost]
        public Object PostTuote([FromBody] Product prodData)
        {
            //validointi?
            nc.Products.Add(prodData);
            nc.SaveChanges();
            return new { ProductId = prodData.ProductId };
        }

        [HttpPut("{id}")]
        public dynamic EditTuote(int id, [FromBody] Product prodData)
        {
            var prod = nc.Products.Find(id);

            if (prod is null) return new { Error = "Not found" };
            //alla oleva koodi kirjoittaa kaikki propertiesit yli
            nc.Entry(prod).CurrentValues.SetValues(prodData);
            nc.SaveChanges();
            return prod;
        }

        [HttpDelete("{id}")]
        public Object DeleteTuote(int id)
        {
            var prod = nc.Products.Find(id);
            if (prod is null) return new { Error = "Not found" };
            nc.Products.Remove(prod);
            nc.SaveChanges();
            return new { Delete = "Success" };
        }
    }
}
