using System.Collections.Generic;

namespace Kolokwium.Models
{
    public class MusicLabel
    {
        public MusicLabel()
        {
            Albums = new HashSet<Album>();
        }
        public int IdMusicLabel { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}