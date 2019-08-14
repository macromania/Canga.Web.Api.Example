using System.IO;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Albums;
using Canga.Web.Api.Example.Storage.SampleData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canga.Web.Api.Example.Test.Storage
{
    [TestClass]
    public class AlbumRepositoryShould
    {
        private const string UserId = "1";
        private const string AlbumId = "1";

        private IAlbumRepository _albumRepository;
        private ISampleDataReader _sampleDataReader;

        [TestInitialize]
        public async Task Init()
        {
            var albumsDataPath = Path.Combine("Storage", "Data", "albums.json");
            var photoDataPath = Path.Combine("Storage", "Data", "photos.json");
            
            _sampleDataReader = new SampleDataReader(albumsDataPath, photoDataPath);
            _albumRepository = new AlbumRepository(_sampleDataReader);
        }
        
        [TestMethod]
        public async Task Return_List_Of_User_Albums()
        {
            // Act
            var result = await _albumRepository.ListUserAlbumsAsync(UserId);
            
            // Assert
            Assert.AreEqual(expected: 10, actual: result.Count);
            
            result.ForEach((album) =>
            {
                Assert.AreEqual(expected: UserId, actual: album.UserId);
            });
        }
        
        [TestMethod]
        public async Task Return_List_Of_User_Album_Photos()
        {
            // Act
            var result = await _albumRepository.ListUserAlbumPhotosAsync(userId: UserId, albumId: AlbumId);
            
            // Assert
            Assert.AreEqual(expected: 50, actual: result.Count);
            
            result.ForEach((photo) =>
            {
                Assert.AreEqual(expected: AlbumId, actual: photo.AlbumId);
            });
        }
    }
}