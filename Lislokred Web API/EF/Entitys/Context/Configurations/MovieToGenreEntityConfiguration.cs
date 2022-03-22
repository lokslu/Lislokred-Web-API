using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lislokred_Web_API.Models.Entitys
{
    class GanreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {

            builder.HasData(new List<Genre>()
            {
                new Genre() {Id =  1, Data = "Detective"},
                new Genre() {Id =  2, Data = "Drama"},
                new Genre() {Id =  3, Data = "Сomedy"},
                new Genre() {Id =  4, Data = "Fantastic"}
            });
        }
    }
    class MovieToGenreEntityConfiguration : IEntityTypeConfiguration<MovieToGenre>
    {
        public void Configure(EntityTypeBuilder<MovieToGenre> builder)
        {

            builder.HasKey(i => new { i.MovieId, i.GanreId });

            builder.HasIndex(i => new { i.MovieId, i.GanreId }).IsUnique();


            builder.HasOne(x => x.Ganre)
                 .WithMany(xf => xf.MovieToGenre)
                 .HasForeignKey(f => f.GanreId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(y => y.Movie)
                 .WithMany(yf => yf.MovieToGenre)
                 .HasForeignKey(f2 => f2.MovieId)
                 .OnDelete(DeleteBehavior.Cascade);
            
        }
    }  

}
