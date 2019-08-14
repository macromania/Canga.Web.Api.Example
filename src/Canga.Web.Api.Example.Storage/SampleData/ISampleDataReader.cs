using System.Collections.Generic;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Model;

namespace Canga.Web.Api.Example.Storage.SampleData
{
    public interface ISampleDataReader
    {
        Task<List<Album>> ReadAlbumsAsync(string albumsDataPath, string photosDataPath);
    }
}