using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuckbillsController : ControllerBase
    {
        [HttpGet]
        public Duckbill[] Get()
        {
            List<Duckbill> duckbills = new List<Duckbill>()
            {
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 1" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 2" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 3" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 4" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 5" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 6" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 7" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 8" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 9" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 10" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 11" },
                new Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 12" },
            };

            return duckbills.ToArray();
        }
    }

    public class Duckbill
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
