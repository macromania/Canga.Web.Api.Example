using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Canga.Web.Api.Example.Storage.Model
{
    public class Album
    {
        private List<AlbumPhoto> _photos;
        
        public string UserId { get; set; }

        public string Id { get; set; }

        public string Title { get; set; }

        [NotNull]
        public List<AlbumPhoto> Photos
        {
            get => _photos = _photos ?? new List<AlbumPhoto>();
            set => _photos = value;
        }
    }
}