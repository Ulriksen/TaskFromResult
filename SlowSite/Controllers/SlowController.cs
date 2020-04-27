using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SlowSite.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SlowController : ControllerBase
    {
        [HttpGet]
        public IActionResult FiveSeconds()
        {
            Console.WriteLine("start");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("got result");
            return Ok(5);
        }
    }
}