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
        public async Task<List<Album>> ReadAlbumsAsync(string albumsDataPath, string photosDataPath)
        {
            var albumsContent = await ReadContent(albumsDataPath);
            var albums = JsonConvert.DeserializeObject<List<Album>>(albumsContent);
            
            var photosContent = await ReadContent(photosDataPath);
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