using System;
using System.Collections.Generic;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class AlbumEfConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(ae => ae.IdAlbum).HasName("Album_pk");
            
            builder.Property(ae => ae.AlbumName).IsRequired();
            builder.Property(ae => ae.PublishDate).IsRequired();

            builder.HasOne(ae => ae.IdMusicLabelNavigation)
                .WithMany(a => a.Albums)
                .HasForeignKey(ae => ae.IdMusicLabel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdMusicLabel_Album");
            
            var albums = new List<Album>();
            albums.Add(new Album {IdAlbum = 1, AlbumName = "albumix", PublishDate = new DateTime(2021, 5, 11), IdMusicLabel = 1});
            albums.Add(new Album {IdAlbum = 2, AlbumName = "music", PublishDate  = new DateTime(2021, 7, 25), IdMusicLabel = 2});
            
            builder.HasData(albums);
        }
    }
}