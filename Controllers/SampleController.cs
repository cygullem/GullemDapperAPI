using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GullemDapperAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        public SampleController()
        {

        }

        [HttpGet("WhoAmI")]
        public IActionResult WhoAmI()
        {
            return Ok("I'm Batman");
        }

        [HttpPost("NiceToMetYou")]
        public IActionResult NiceToMetYou(string? yourName)
        {
            if (string.IsNullOrEmpty(yourName))
            {
                return BadRequest("Provide a name first");
            }
            return Ok($"nice to meet you {yourName}");
        }
    }
}