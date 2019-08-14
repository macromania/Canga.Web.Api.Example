using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Canga.Web.Api.Example.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Returns a welcome message for API Health purposes
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                message = Startup.ApiName,
                docs = $"https://{Request.Host}/docs",
            });
        }
    }
}