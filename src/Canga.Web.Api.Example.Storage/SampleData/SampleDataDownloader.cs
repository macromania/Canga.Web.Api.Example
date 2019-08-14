using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;
using Newtonsoft.Json;

namespace Canga.Web.Api.Example.Storage.SampleData
{
    public class SampleDataDownloader : ISampleDataReader
    {
        private readonly string _albumsDataPath;
        private readonly string _photosDataPath;

        public SampleDataDownloader(string albumsDataPath, string photosDataPath)
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
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://jsonplaceholder.typicode.com");
            var response = await httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}