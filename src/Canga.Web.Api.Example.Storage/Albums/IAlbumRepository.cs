using System.Collections.Generic;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;

namespace Canga.Web.Api.Example.Storage.Albums
{
    public interface IAlbumRepository : IStorageRepository<Album>
    {
        Task<List<Album>> ListUserAlbumsAsync(string userId);

        Task<List<AlbumPhoto>> ListUserAlbumPhotosAsync(string userId, string albumId);
    }
}