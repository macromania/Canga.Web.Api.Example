using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;

namespace Canga.Web.Api.Example.Storage.Albums
{
    public class AlbumRepository : IAlbumRepository
    {
        public async Task<List<Album>> ListUserAlbumsAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<AlbumPhoto>> ListUserAlbumPhotosAsync(string userId, string albumId)
        {
            throw new System.NotImplementedException();
        }
    }
}