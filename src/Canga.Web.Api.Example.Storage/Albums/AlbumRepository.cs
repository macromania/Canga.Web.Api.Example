using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;
using Canga.Web.Api.Example.Storage.SampleData;

namespace Canga.Web.Api.Example.Storage.Albums
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ISampleDataReader _sampleDataReader;
        
        private readonly string _albumsDataPath;
        private readonly string _photosDataPath;
        
        public AlbumRepository(ISampleDataReader sampleDataReader)
        {
            _albumsDataPath = Path.Combine("SampleData", "Data", "albums.json");
            _photosDataPath = Path.Combine("SampleData", "Data", "photos.json");
            
            _sampleDataReader = sampleDataReader;
        }
        
        public async Task<List<Album>> ListUserAlbumsAsync(string userId)
        {
            var albums = await _sampleDataReader.ReadAlbumsAsync();
            return albums
                .Where(i => i.UserId == userId)
                .ToList();
        }

        public async Task<List<AlbumPhoto>> ListUserAlbumPhotosAsync(string userId, string albumId)
        {
            var albums = await _sampleDataReader.ReadAlbumsAsync();
            return albums
                .Where(i => i.UserId == userId && i.Id == albumId)
                .SelectMany(i => i.Photos)
                .ToList();
        }
    }
}