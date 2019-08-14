using System.Threading.Tasks;
using Canga.Web.Api.Example.Storage.Albums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Canga.Web.Api.Example.Test.Storage
{
    [TestClass]
    public class AlbumRepositoryShould
    {
        private const string UserId = "1";
        private const string AlbumId = "1";

        private IAlbumRepository _albumRepository;
        
        [TestMethod]
        public async Task Return_List_Of_User_Albums()
        {
            // Arrange
            var _albumRepository = new AlbumRepository();
            
            // Act
            var result = await _albumRepository.ListUserAlbumsAsync(UserId);
            
            // Assert
            Assert.AreEqual(expected: 10, actual: result.Count);
        }
        
        [TestMethod]
        public async Task Return_List_Of_User_Album_Photos()
        {
            // Arrange
            var _albumRepository = new AlbumRepository();
            
            // Act
            var result = await _albumRepository.ListUserAlbumPhotosAsync(userId: UserId, albumId: AlbumId);
            
            // Assert
            Assert.AreEqual(expected: 50, actual: result.Count);
        }
    }
}