using System;
using System.Collections.Generic;

namespace Kolokwium.Models
{
    public class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
        public virtual MusicLabel IdMusicLabelNavigation  { get; set; }
    }
}