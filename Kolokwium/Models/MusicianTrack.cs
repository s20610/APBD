namespace Kolokwium.Models
{
    public class MusicianTrack
    {
        public int IdTrack { get; set; }
        public int IdMusician{ get; set; }

        public virtual Track IdTrackNavigation  { get; set; }
        public virtual Musician IdMusicianNavigation  { get; set; }
    }
}