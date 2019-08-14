using System.Collections.Generic;
using System.Threading.Tasks;
using Canga.Web.Api.Example.Contract.Response;
using Canga.Web.Api.Example.Storage.Albums;

namespace Canga.Web.Api.Example.Service.Albums
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository) => _albumRepository = albumRepository;
        
        public async Task<List<AlbumResponse>> ListUserAlbumsAsync(string userId)
        {
            var userAlbums = await _albumRepository.ListUserAlbumsAsync(userId);
            var userAlbumResponses = AlbumConverter.ConvertToAlbumResponses(userAlbums);
            return userAlbumResponses;
        }

        public async Task<List<AlbumPhotoResponse>> ListUserAlbumPhotosAsync(string userId, string albumId)
        {
            var userAlbumPhotos = await _albumRepository.ListUserAlbumPhotosAsync(userId, albumId);
            var userAlbumPhotoResponses = AlbumConverter.ConvertToAlbumPhotoResponses(userAlbumPhotos);
            return userAlbumPhotoResponses;
        }
    }
}