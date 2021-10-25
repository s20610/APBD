using System.Collections.Generic;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium.Configurations
{
    public class MusicianEfConfiguration : IEntityTypeConfiguration<Musician>
    {
        public void Configure(EntityTypeBuilder<Musician> builder)
        {
            
            builder.HasKey(d => d.IdMusician).HasName("Musician_pk");
            builder.Property(d => d.IdMusician).UseIdentityColumn();

            builder.Property(a => a.FirstName).HasMaxLength(30).IsRequired();
            builder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
            builder.Property(a => a.Nickname).HasMaxLength(20);

            var musicians = new List<Musician>();
            musicians.Add(new Musician{IdMusician = 1, FirstName = "Baby", LastName = "BB", Nickname = "Yoda"});
            musicians.Add(new Musician{IdMusician = 2, FirstName = "AC", LastName = "DC" , Nickname = "ACDC"});
            
            builder.HasData(musicians);
        }
    }
}