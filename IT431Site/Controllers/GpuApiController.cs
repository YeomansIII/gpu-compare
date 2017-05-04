using IT431Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IT431Site.Controllers
{
    public class GpuApiController : ApiController
    {
        private GraphicsCardsDataEntities db = new GraphicsCardsDataEntities();

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Dictionary<string, object>> Autocomplete()
        {
            var gpuCards = db.GPUCards.Select(g => new
            {
                GPUCardID = g.GPUCardID,
                Chipset = g.Chipset,
                Manufacturer = g.Manufacturer
            }).ToArray();
            Dictionary<string, object>[] autocompletes = new Dictionary<string, object>[gpuCards.Length];
            for (int i = 0; i < gpuCards.Length; i++)
            {
                var gpu = gpuCards[i];
                Dictionary<String, Object> autocomplete = new Dictionary<string, object>();
                autocomplete["id"] = gpu.GPUCardID;
                autocomplete["label"] = gpu.Manufacturer.ManufacturerName + " " + gpu.Chipset.ChipsetName;
                autocompletes[i] = autocomplete;
            }
            return autocompletes;
        }

        [HttpGet]
        public Dictionary<string, object> Compare([FromUri] int id1, [FromUri] int id2)
        {
            GPUCard gpu1 = db.GPUCards.Where(g => g.GPUCardID == id1).Single();
            GPUCard gpu2 = db.GPUCards.Where(g => g.GPUCardID == id2).Single();
            Dictionary<String, Object> toCompareDict = new Dictionary<string, object>();
            toCompareDict["gpu1"] = gpu1;
            toCompareDict["gpu2"] = gpu2;
            return toCompareDict; 
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}