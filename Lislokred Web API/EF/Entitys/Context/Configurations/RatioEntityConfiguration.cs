using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lislokred_Web_API.Models.Entitys
{
    class RatioEntityConfiguration : IEntityTypeConfiguration<Ratio>
    {
        public void Configure(EntityTypeBuilder<Ratio> builder)
        {

            builder.HasKey(i => new { i.MovieId, i.FilmUnitId});

            builder.HasIndex(i => new { i.MovieId, i.FilmUnitId}).IsUnique();


            builder.HasOne(x => x.Movie)
                 .WithMany(xf => xf.Ratios)
                 .HasForeignKey(f => f.MovieId )
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(y => y.FilmUnit)
                 .WithMany(yf => yf.Ratios)
                 .HasForeignKey(f2 => f2.FilmUnitId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Role).HasDefaultValue("Актёр");
        
        }
    }

}
