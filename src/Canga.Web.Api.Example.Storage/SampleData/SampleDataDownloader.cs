using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;

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
            var photosContent = await ReadContent(_photosDataPath);
            var albums = SampleDataParser.Parse(albumsContent, photosContent);
            return albums;
        }
        
        private static async Task<string> ReadContent(string path)
        {
            var httpClient = new HttpClient {BaseAddress = new Uri("http://jsonplaceholder.typicode.com")};
            var response = await httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}