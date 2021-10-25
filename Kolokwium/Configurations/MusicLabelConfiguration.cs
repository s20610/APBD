using System.Collections.Generic;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class MusicLabelEfConfiguration : IEntityTypeConfiguration<MusicLabel>
    {
        public void Configure(EntityTypeBuilder<MusicLabel> builder)
        {
            
            builder.HasKey(d => d.IdMusicLabel).HasName("MusicLabel_pk");
            builder.Property(d => d.IdMusicLabel).UseIdentityColumn();

            builder.Property(a => a.Name).HasMaxLength(50).IsRequired();
          

            var musiclabels = new List<MusicLabel>();
            musiclabels.Add(new MusicLabel{IdMusicLabel = 1, Name = "cos"});
            musiclabels.Add(new MusicLabel{IdMusicLabel = 2, Name = "to"});
            
            builder.HasData(musiclabels);
        }
    }
}