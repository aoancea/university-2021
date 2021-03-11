using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuckbillsController : ControllerBase
    {
        private static List<Models.Duckbill> duckbills = new List<Models.Duckbill>()
        {
            new Models.Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill1" },
            new Models.Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill2" },
            new Models.Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill3" },
            new Models.Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill4" },
            new Models.Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill5" }
        };

        [HttpGet]
        public Models.Duckbill[] Get()
        {
            return duckbills.ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Models.Duckbill duckbill)
        {
            if (duckbill.ID == Guid.Empty)
                duckbill.ID = Guid.NewGuid();

            duckbills.Add(duckbill);
        }

        [HttpPut]
        public void Put([FromBody] Models.Duckbill duckbill)
        {
            Models.Duckbill currentDuckbill = duckbills.FirstOrDefault(x => x.ID == duckbill.ID);
            currentDuckbill.Name = duckbill.Name;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            duckbills.RemoveAll(duckbill => duckbill.ID == id);

            //foreach (Models.Duckbill duckbill in duckbills)
            //{
            //    if (duckbill.ID == id)
            //    {
            //        duckbills.Remove(duckbill);
            //    }
            //}
        }
    }
}