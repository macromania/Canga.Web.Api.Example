using System.Collections.Generic;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;

namespace Canga.Web.Api.Example.Storage.SampleData
{
    public class SampleDataReader : ISampleDataReader
    {
        private readonly string _albumsDataPath;
        private readonly string _photosDataPath;

        private readonly IContentReader _contentReader;

        public SampleDataReader(string albumsDataPath, string photosDataPath, IContentReader contentReader)
        {
            _albumsDataPath = albumsDataPath;
            _photosDataPath = photosDataPath;
            _contentReader = contentReader;
        }
        public async Task<List<Album>> ReadAlbumsAsync()
        {
            var albumsContent = await _contentReader.ReadContent(_albumsDataPath);
            var photosContent = await _contentReader.ReadContent(_photosDataPath);
            var albums = SampleDataParser.Parse(albumsContent, photosContent);
            return albums;
        }
    }
}