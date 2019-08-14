using System.Collections.Generic;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Contract.Response;

namespace Canga.Web.Api.Example.Service.Albums
{
    public interface IAlbumService
    {
        Task<List<AlbumResponse>> ListUserAlbumsAsync(string userId);

        Task<List<AlbumPhotoResponse>> ListUserAlbumPhotosAsync(string userId, string albumId);
    }
}