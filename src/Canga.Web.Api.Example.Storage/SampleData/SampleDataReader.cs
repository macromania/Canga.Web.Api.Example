using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;
using Newtonsoft.Json;

namespace Canga.Web.Api.Example.Storage.SampleData
{
    public class SampleDataReader : ISampleDataReader
    {
        private readonly string _albumsDataPath;
        private readonly string _photosDataPath;

        public SampleDataReader(string albumsDataPath, string photosDataPath)
        {
            _albumsDataPath = albumsDataPath;
            _photosDataPath = photosDataPath;
        }
        public async Task<List<Album>> ReadAlbumsAsync()
        {
            var albumsContent = await ReadContent(_albumsDataPath);
            var albums = JsonConvert.DeserializeObject<List<Album>>(albumsContent);
            
            var photosContent = await ReadContent(_photosDataPath);
            var photos = JsonConvert.DeserializeObject<List<AlbumPhoto>>(photosContent);
            
            photos.ForEach((photo) =>
            {
                var album = albums.FirstOrDefault(i => i.Id == photo.AlbumId);
                album?.Photos.Add(photo);
            });

            return albums;
        }
        
        private static async Task<string> ReadContent(string path)
        {
            var content = await File.ReadAllTextAsync(path);
            return content;
        }
    }
}