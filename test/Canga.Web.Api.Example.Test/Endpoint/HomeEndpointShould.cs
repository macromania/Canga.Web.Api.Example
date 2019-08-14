using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Canga.Web.Api.Example.Test.Endpoint
{
    [TestClass]
    public class HomeEndpointShould
    {
        [TestMethod]
        public async Task Return_ApiName_And_Docs_Url()
        {
            // Arrange
            var apiName = Startup.ApiName;
            var docsUrl = "https://localhost/docs";
            var httpClient = new WebApplicationFactory<Startup>().CreateClient();

            // Act
            var homeResponse = await httpClient.GetAsync("/");
            homeResponse.EnsureSuccessStatusCode();

            var homeResponseContent = await homeResponse.Content.ReadAsAsync<JObject>();

            // Assert
            Assert.AreEqual(apiName, homeResponseContent["message"].ToString());
            Assert.AreEqual(docsUrl, homeResponseContent["docs"].ToString());
        }
    }
}