using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lislokred_Web_API.Models.Entitys
{
    class UserToGanreEntityConfiguration : IEntityTypeConfiguration<UserToGenre>
    {
        public void Configure(EntityTypeBuilder<UserToGenre> builder)
        {

            builder.HasKey(i => new { i.UserId, i.GanreId });

            builder.HasIndex(i => new { i.UserId, i.GanreId }).IsUnique();


            builder.HasOne(x => x.Ganre)
                 .WithMany(xf => xf.UserToGenre)
                 .HasForeignKey(f => f.GanreId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(y => y.User)
                 .WithMany(yf => yf.UserToGenre)
                 .HasForeignKey(f2 => f2.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
