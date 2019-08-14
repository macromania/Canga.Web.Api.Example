using System.Collections.Generic;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Contract.Response;
using Canga.Web.Api.Example.Storage.Model;

namespace Canga.Web.Api.Example.Storage.Albums
{
    public interface IAlbumRepository : IStorageRepository<Album>
    {
        Task<List<AlbumResponse>> ListUserAlbumsAsync(string userId);

        Task<List<AlbumPhotoResponse>> ListUserAlbumPhotosAsync(string userId, string albumId);
    }
}