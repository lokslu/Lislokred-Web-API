using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lislokred_Web_API.Models.Entitys
{
    class ImageUnitEntityConfiguration : IEntityTypeConfiguration<ImageUnit>
    {
        public void Configure(EntityTypeBuilder<ImageUnit> builder)
        {

            builder.HasKey(i => new { i.Id });

            builder.HasIndex(i => new { i.Id }).IsUnique();


            builder.HasOne(x => x.Unit)
                 .WithMany(xf => xf.ImagesUnit)
                 .HasForeignKey(f => f.UnitId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
