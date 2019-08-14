using System.Net.Http;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Canga.Web.Api.Example.Test.Endpoint
{
    [TestClass]
    public class HomeEndpointShould
    {
        [TestMethod]
        public async Task Return_Welcome_Message()
        {
            // Arrange
            var apiName = Startup.ApiName;
            var apiDescription = Startup.ApiDescription;
            var apiVersion = Startup.ApiVersion;
            var docsUrl = "https://localhost/docs";
            var httpClient = new WebApplicationFactory<Startup>().CreateClient();

            // Act
            var response = await httpClient.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<JObject>();

            // Assert
            Assert.AreEqual(expected: apiName, actual: result["message"].ToString());
            Assert.AreEqual(expected: apiDescription, actual: result["details"].ToString());
            Assert.AreEqual(expected: apiVersion, actual: result["version"].ToString());
            Assert.AreEqual(expected: docsUrl, actual: result["docs"].ToString());
        }
    }
}