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
    public class AlbumPhotosEndpointShould
    {
        private const string UserId = "1";
        private const string AlbumId = "1";
        
        [TestMethod]
        public async Task Return_List_Of_Album_Photos()
        {
            // Arrange
            var httpClient = new WebApplicationFactory<Startup>().CreateClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Id", UserId);

            // Act
            var response = await httpClient.GetAsync($"/albums/{AlbumId}/photos");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<List<AlbumPhotoResponse>>();

            // Assert
            Assert.AreEqual(expected: 0, actual: result.Count);
        }
    }
}