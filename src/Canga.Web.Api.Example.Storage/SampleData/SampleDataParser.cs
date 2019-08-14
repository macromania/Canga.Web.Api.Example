using System.Collections.Generic;
using System.Linq;
using Canga.Web.Api.Example.Storage.Model;
using Newtonsoft.Json;

namespace Canga.Web.Api.Example.Storage.SampleData
{
    internal static class SampleDataParser
    {
        internal static List<Album> Parse(string albumData, string photoData)
        {
            var albums = JsonConvert.DeserializeObject<List<Album>>(albumData);
            var photos = JsonConvert.DeserializeObject<List<AlbumPhoto>>(photoData);
            
            photos.ForEach((photo) =>
            {
                var album = albums.FirstOrDefault(i => i.Id == photo.AlbumId);
                album?.Photos.Add(photo);
            });

            return albums;
        }
    }
}