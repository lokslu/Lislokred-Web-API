using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lislokred_Web_API.Models.Entitys
{
    class ImageUserEntityConfiguration : IEntityTypeConfiguration<ImageUser>
    {
        public void Configure(EntityTypeBuilder<ImageUser> builder)
        {

            builder.HasKey(i => new { i.Id });

            builder.HasIndex(i => new { i.Id }).IsUnique();


            builder.HasOne(x => x.User)
                 .WithMany(xf => xf.ImageUsers)
                 .HasForeignKey(f => f.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
