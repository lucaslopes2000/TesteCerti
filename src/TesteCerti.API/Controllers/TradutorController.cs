using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TesteCerti.API.Models;

namespace TesteCerti.API.Controllers
{
    [ApiController]
    [Route("")]
    public class TradutorController : ControllerBase
    {
        public TradutorController()
        {
            
        }

        [HttpGet("{number}")]
        public Tradutor Get(int number)
        {
            var name = Convert.ToString(number);

            return new Tradutor() {
                Extenso = name
            };
        }
    }
}
