using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Api;
using Canga.Web.Api.Example.Contract.Response;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Canga.Web.Api.Example.Test.Endpoint
{
    [TestClass]
    public class AlbumsEndpointShould
    {
        private const string UserId = "1";
        
        [TestMethod]
        public async Task Return_List_Of_Albums()
        {
            // Arrange
            var httpClient = new WebApplicationFactory<Startup>().CreateClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Id", UserId);

            // Act
            var response = await httpClient.GetAsync("/albums");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<List<AlbumResponse>>();

            // Assert
            Assert.AreEqual(expected: 10, actual: result.Count);
            
            result.ForEach((album) =>
            {
                Assert.AreEqual(expected: UserId, actual: album.UserId);
            });
        }
    }
}