using Kolokwium.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Musician> Musician{ get; set; }
        public virtual DbSet<MusicianTrack> MusicianTrack { get; set; }
        public virtual DbSet<Track> Track { get; set; }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<MusicLabel> MusicLabel { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.ApplyConfiguration(new MusicianEfConfiguration());
          modelBuilder.ApplyConfiguration(new MusicianTrackEfConfiguration());
          modelBuilder.ApplyConfiguration(new TrackEfConfiguration());
          modelBuilder.ApplyConfiguration(new AlbumEfConfiguration());
          modelBuilder.ApplyConfiguration(new MusicLabelEfConfiguration());
        }
    }
}