using System.Collections.Generic;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class MusicianTrackEfConfiguration : IEntityTypeConfiguration<MusicianTrack>
    {
        public void Configure(EntityTypeBuilder<MusicianTrack> builder)
        {
            builder.HasKey(ae => new {ae.IdTrack, ae.IdMusician}).HasName("Musician_Track_PK");

            builder.ToTable("Musician_Track");
            builder.HasOne(ae => ae.IdMusicianNavigation)
                .WithMany(a => a.MusicianTracks)
                .HasForeignKey(ae => ae.IdMusician)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Musician_Musician_Track");

            builder.HasOne(ae => ae.IdTrackNavigation)
                .WithMany(e => e.MusicianTracks)
                .HasForeignKey(ae => ae.IdTrack)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Track_Musician_Track");
        
            
            var musicianTracks = new List<MusicianTrack>();
            musicianTracks.Add(new MusicianTrack {IdMusician = 1, IdTrack = 1});
            musicianTracks.Add(new MusicianTrack{IdMusician = 2, IdTrack = 2});
            
            builder.HasData(musicianTracks);
        }
    }
}