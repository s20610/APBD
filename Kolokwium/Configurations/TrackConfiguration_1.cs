using System;
using System.Collections.Generic;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class TrackEfConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.HasKey(ae => ae.IdTrack).HasName("Track_pk");
            
            builder.Property(ae => ae.TrackName).HasMaxLength(20).IsRequired();
            builder.Property(ae => ae.Duration).IsRequired();

            builder.HasOne(ae => ae.IdAlbumNavigation)
                .WithMany(a => a.Tracks)
                .HasForeignKey(ae => ae.IdMusicAlbum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdMusicLabel_Album").IsRequired(false);
            
            var tracks = new List<Track>();
            tracks.Add(new Track {IdTrack = 1, TrackName = "Siemandero", Duration = (float) 3.5 , IdMusicAlbum = 1});
            tracks.Add(new Track {IdTrack= 2, TrackName = "GIT",Duration = (float) 3.5, IdMusicAlbum = 2});
            
            builder.HasData(tracks);
        }
    }
}