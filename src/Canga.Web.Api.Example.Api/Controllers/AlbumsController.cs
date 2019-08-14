using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Contract.Response;
using Canga.Web.Api.Example.Service.Albums;
using Canga.Web.Api.Example.Storage.Albums;
using Microsoft.AspNetCore.Mvc;

namespace Canga.Web.Api.Example.Api.Controllers
{
    /// <summary>
    /// Albums Endpoint
    /// </summary>
    /// <response code="400">Invalid request when User-Id is missing or empty in headers</response>
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        /// <summary>
        /// Albums Controller
        /// </summary>
        /// <param name="albumService">Storage repository to read album data</param>
        public AlbumsController(IAlbumService albumService) => _albumService = albumService;
        
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
            var result = await _albumService.ListUserAlbumsAsync(userId);
            return Ok(result);
        }
    }
}