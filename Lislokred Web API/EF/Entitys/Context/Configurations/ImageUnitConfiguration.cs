using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lislokred_Web_API.Models.Entitys
{
    class ImageUnitConfiguration : IEntityTypeConfiguration<ImageUnit>
    {
        public void Configure(EntityTypeBuilder<ImageUnit> builder)
        {

            builder.HasKey(i => i.Id);

            builder.HasIndex(i => i.Id).IsUnique();

        }
    }

}
