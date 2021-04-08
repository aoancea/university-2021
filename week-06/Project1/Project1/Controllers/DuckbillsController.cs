﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DuckbillsController : ControllerBase
    {
        private readonly ILogger<DuckbillsController> _logger;

        public DuckbillsController(ILogger<DuckbillsController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IEnumerable<Models.Duckbill> Get()
        {
            return new Models.Duckbill[2]
            {
                new Models.Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 1" },
                new Models.Duckbill() { ID = Guid.NewGuid(), Name = "Duckbill 2" }
            };
        }
    }
}
