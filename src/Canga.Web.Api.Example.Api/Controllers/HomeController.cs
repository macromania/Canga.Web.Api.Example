using Microsoft.AspNetCore.Mvc;

namespace Canga.Web.Api.Example.Api.Controllers
{
    /// <summary>
    /// Home Endpoint
    /// </summary>
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
                details = Startup.ApiDescription,
                version = Startup.ApiVersion,
                docs = $"https://{Request.Host}/docs",
            });
        }
    }
}