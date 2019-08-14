using System.Collections.Generic;
using Canga.Web.Api.Example.Contract.Response;
using Canga.Web.Api.Example.Storage.Model;

namespace Canga.Web.Api.Example.Service.Albums
{
    internal class AlbumConverter
    {
        internal static List<AlbumResponse> ConvertToAlbumResponses(List<Album> albums)
        {
            var albumResponses = new List<AlbumResponse>();
            albums.ForEach((album) =>
            {
                var albumResponse = new AlbumResponse
                {
                    Id = album.Id,
                    Title = album.Title,
                    UserId = album.UserId
                };
                
                albumResponses.Add(albumResponse);
            });

            return albumResponses;
        }
        
        internal static List<AlbumPhotoResponse> ConvertToAlbumPhotoResponses(List<AlbumPhoto> albumPhotos)
        {
            var albumPhotoResponses = new List<AlbumPhotoResponse>();
            albumPhotos.ForEach((albumPhoto) =>
            {
                var albumPhotoResponse = new AlbumPhotoResponse
                {
                    Id = albumPhoto.Id,
                    Title = albumPhoto.Title,
                    Url = albumPhoto.Url,
                    AlbumId =  albumPhoto.AlbumId,
                    ThumbnailUrl = albumPhoto.ThumbnailUrl
                };
                
                albumPhotoResponses.Add(albumPhotoResponse);
            });

            return albumPhotoResponses;
        }
    }
}