using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiKurssi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Harjoitus1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public string Get()
        {
            return "Harjoitukset #1";
        }

        [HttpGet]
        [Route("luku")]
        public int Luku()
        {
            return new Random().Next(1, 9999);
        }
        [HttpGet]
        [Route("tekstia")]
        public string Tekstia()
        {
            return "kuppikakku";
        }
        [HttpGet]
        [Route("merkkijonoja")]
        public IList<string> Merkkijonoja()
        {
            return new List<string>()
            {
                "abc","cde","efg"
            };
        }

        [HttpGet]
        [Route("autoja")]
        public IEnumerable<Auto> Autoja()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Auto
            {
                Merkki = new string[] { "Mersu", "BMW", "Audi", "Renault", "Opel", "Tesla", "Talbot" }[rng.Next(0, 6)],
                Vuosimalli = rng.Next(1977, 2021),
                Mittarilukema = rng.Next(0, 500000),
                Rekisterissa = rng.Next(2) > 0
            })
            .ToArray();
        }
    }
}
