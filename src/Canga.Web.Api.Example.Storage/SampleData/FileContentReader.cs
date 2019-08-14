using System.IO;
using System.Threading.Tasks;

namespace Canga.Web.Api.Example.Storage.SampleData
{
    public class FileContentReader : IContentReader
    {
        public async Task<string> ReadContent(string path)
        {
            var content = await File.ReadAllTextAsync(path);
            return content;
        }
    }
}