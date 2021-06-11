using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lislokred_Web_API.Models.Entitys
{
    class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            builder.HasKey(i => new { i.Id });

            builder.HasIndex(i => new { i.Id }).IsUnique();

            builder.HasIndex(i => new { i.ImdbId}).IsUnique();

        }
    }

}
