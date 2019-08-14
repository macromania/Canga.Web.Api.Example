using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;
using Canga.Web.Api.Example.Storage.SampleData;

namespace Canga.Web.Api.Example.Storage.Albums
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ISampleDataReader _sampleDataReader;
        
        public AlbumRepository(ISampleDataReader sampleDataReader)
        {
            _sampleDataReader = sampleDataReader;
        }
        
        public async Task<List<Album>> ListUserAlbumsAsync(string userId)
        {
            var albums = await _sampleDataReader.ReadAlbumsAsync();
            var userAlbums = albums
                .Where(i => i.UserId == userId)
                .ToList();

            return userAlbums;
        }

        public async Task<List<AlbumPhoto>> ListUserAlbumPhotosAsync(string userId, string albumId)
        {
            var albums = await _sampleDataReader.ReadAlbumsAsync();
            var userAlbumPhotos = albums
                .Where(i => i.UserId == userId && i.Id == albumId)
                .SelectMany(i => i.Photos)
                .ToList();

            return userAlbumPhotos;
        }
    }
}