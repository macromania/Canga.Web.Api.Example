using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Canga.Web.Api.Example.Storage.SampleData
{
    public class HttpContentReader : IContentReader
    {
        private readonly string _baseUrl;
        
        public HttpContentReader(string baseUrl) => _baseUrl = baseUrl;
        
        public async Task<string> ReadContent(string path)
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(_baseUrl)};
            var response = await httpClient.GetAsync(path);
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}