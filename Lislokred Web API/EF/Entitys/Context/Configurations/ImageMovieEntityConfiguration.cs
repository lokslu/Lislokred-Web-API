using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lislokred_Web_API.Models.Entitys
{
    class ImageMovieEntityConfiguration : IEntityTypeConfiguration<ImageMovie>
    {
        public void Configure(EntityTypeBuilder<ImageMovie> builder)
        {

            builder.HasKey(i => new { i.Id});

            builder.HasIndex(i => new { i.Id}).IsUnique();


            builder.HasOne(x => x.Movie)
                 .WithMany(xf => xf.ImageMovies)
                 .HasForeignKey(f => f.MovieId )
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
