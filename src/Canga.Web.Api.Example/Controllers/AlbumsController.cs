using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Contract.Response;
using Microsoft.AspNetCore.Mvc;

namespace Canga.Web.Api.Example.Controllers
{
    /// <summary>
    /// Albums Endpoint
    /// </summary>
    /// <response code="400">Invalid request when User-Id is missing or empty in headers</response>
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        /// <summary>
        /// Returns list of albums for a given user
        /// </summary>
        /// <param name="userId">Authenticated User ID</param>
        /// <response code="200">Returns list of <see cref="AlbumResponse"/></response>
        [HttpGet]
        [Route("/albums")]
        public async Task<ActionResult<List<AlbumResponse>>> ListAlbumsAsync(
            [FromHeader(Name = "User-Id"), Required(ErrorMessage = "Request Header is missing User-Id value", AllowEmptyStrings = false)] string userId)
        {
            return Ok(new List<AlbumResponse>());
        }
    }
}