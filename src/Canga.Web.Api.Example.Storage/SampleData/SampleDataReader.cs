using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;

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
            var photosContent = await ReadContent(_photosDataPath);
            var albums = SampleDataParser.Parse(albumsContent, photosContent);
            return albums;
        }
        
        private static async Task<string> ReadContent(string path)
        {
            var content = await File.ReadAllTextAsync(path);
            return content;
        }
    }
}