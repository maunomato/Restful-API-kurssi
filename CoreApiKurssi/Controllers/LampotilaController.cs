using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreApiKurssi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LampotilaController : Controller
    {
        /// <summary>
        /// API kutsu jolla saa tietyn sääaseman osittaisen datakokoelman FMIAsema-luokan kuvauksen mukaisesti.
        /// </summary>
        /// <param name="fmisid">Sääaseman tunniste</param>
        /// <returns>FMIAsema</returns>
        [HttpGet]
        [Route("asema/{fmisid}")]
        public FMIAsema GetFMIAsemaTiedot(int fmisid)
        {
            string url = "https://ilmatieteenlaitos.fi/observation-data?station=" + fmisid;
            using (var httpClient = new HttpClient())
            {
                //httpClient.DefaultRequestHeaders.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);
                var jsonString = httpClient.GetStringAsync(new Uri(url)).Result;

                return JsonConvert.DeserializeObject<FMIAsema>(jsonString);
            }

        }

        [HttpGet("{fmisid}")]
        public Object Lampotila(int fmisid)
        {
            FMIAsema asema = GetFMIAsemaTiedot(fmisid);
            
            return new { 
                    aika = asema.LatestObservationTime, 
                    lämpötila = asema.LatestTemp
            };
        }
    }
}
