using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Contract.Response;
using Canga.Web.Api.Example.Storage.Albums;
using Microsoft.AspNetCore.Mvc;

namespace Canga.Web.Api.Example.Api.Controllers
{
    /// <summary>
    /// Albums Endpoint
    /// </summary>
    /// <response code="400">Invalid request when User-Id is missing or empty in headers</response>
    [ApiController]
    public class AlbumPhotosController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        
        /// <summary>
        /// AlbumPhotos Controller
        /// </summary>
        /// <param name="albumRepository">Storage repository to read album data</param>
        public AlbumPhotosController(IAlbumRepository albumRepository) => _albumRepository = albumRepository;
        
        /// <summary>
        /// Returns list of photos of an album for a given user
        /// </summary>
        /// <param name="userId">Authenticated User ID</param>
        /// <param name="albumId">Album ID</param>
        /// <response code="200">Returns list of <see cref="AlbumPhotoResponse"/></response>
        [HttpGet]
        [Route("/albums/{albumId}/photos")]
        public async Task<ActionResult<List<AlbumPhotoResponse>>> ListAlbumPhotosAsync(
            [FromHeader(Name = "User-Id"), Required(ErrorMessage = "Request Header is missing User-Id value", AllowEmptyStrings = false)] string userId,
            [Required(ErrorMessage = "Album ID is missing in the URL", AllowEmptyStrings = false)] string albumId)
        {
            var result = await _albumRepository.ListUserAlbumPhotosAsync(userId, albumId);
            return Ok(result);
        }
    }
}