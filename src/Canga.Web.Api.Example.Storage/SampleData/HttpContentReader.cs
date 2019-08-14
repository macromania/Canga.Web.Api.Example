using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Canga.Web.Api.Example.Storage.SampleData
{
    public class HttpContentReader : IContentReader
    {
        public async Task<string> ReadContent(string path)
        {
            var httpClient = new HttpClient {BaseAddress = new Uri("http://jsonplaceholder.typicode.com")};
            var response = await httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}