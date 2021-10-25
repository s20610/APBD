using System.Collections.Generic;

namespace Kolokwium.Models
{
    public class Track
    {
        public Track()
        { 
            MusicianTracks = new HashSet<MusicianTrack>();
        }
        public int IdTrack { get; set; }
        public string TrackName { get; set; }
        public float Duration { get; set; }
        public int? IdMusicAlbum { get; set; }

        public virtual ICollection<MusicianTrack> MusicianTracks { get; set; }
        public virtual Album IdAlbumNavigation  { get; set; }
    }
}