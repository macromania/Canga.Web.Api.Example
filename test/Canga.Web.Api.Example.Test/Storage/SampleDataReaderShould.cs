using System.IO;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.SampleData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canga.Web.Api.Example.Test.Storage.SampleData
{
    [TestClass]
    public class SampleDataReaderShould
    {
        private ISampleDataReader _sampleDataReader;
        
        [TestMethod]
        public async Task Read_All_Data()
        {
            // Arrange
            var albumsDataPath = Path.Combine("Storage", "Data", "albums.json");
            var photoDataPath = Path.Combine("Storage", "Data", "photos.json");
            _sampleDataReader = new SampleDataReader();
            
            // Act
            var result = await _sampleDataReader.ReadAlbumsAsync(albumsDataPath, photoDataPath);
            
            // Assert
            Assert.AreEqual(expected: 100, actual: result.Count);
            
            result.ForEach((album) =>
            {
                Assert.AreEqual(expected: 50, actual: album.Photos.Count);
                
                album.Photos.ForEach((photo) =>
                {
                    Assert.AreEqual(expected: album.Id, actual: photo.AlbumId);
                });
            });
        }
    }
}