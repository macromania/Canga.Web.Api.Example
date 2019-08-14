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
    public class AlbumPhotosController : ControllerBase
    {
        /// <summary>
        /// Returns list of photos of an album for a given user
        /// </summary>
        /// <param name="userId">Authenticated User ID</param>
        /// <param name="albumId">Album ID</param>
        /// <response code="200">Returns list of <see cref="AlbumResponse"/></response>
        [HttpGet]
        [Route("/albums/{albumId}/photos")]
        public async Task<ActionResult<List<PhotoResponse>>> ListAlbumPhotosAsync(
            [FromHeader(Name = "User-Id"), Required(ErrorMessage = "Request Header is missing User-Id value", AllowEmptyStrings = false)] string userId,
            [Required(ErrorMessage = "Album ID is missing in the URL", AllowEmptyStrings = false)] string albumId)
        {
            return Ok(new List<PhotoResponse>());
        }
    }
}