namespace Canga.Web.Api.Example.Contract.Response
{
    public abstract class AlbumPhotoResponse
    {
        public string AlbumId { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}