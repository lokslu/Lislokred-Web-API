using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lislokred_Web_API.Models.Entitys
{
    class StateAndRateEntityConfiguration : IEntityTypeConfiguration<StateAndRate>
    {
        public void Configure(EntityTypeBuilder<StateAndRate> builder)
        {

            builder.HasKey(i => new { i.MovieId, i.UserId });

            builder.HasIndex(i => new { i.MovieId, i.UserId }).IsUnique();


            builder.HasOne(x => x.Movie)
                 .WithMany(xf => xf.StateAndRate)
                 .HasForeignKey(f => f.MovieId )
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(y => y.User)
                 .WithMany(yf => yf.StateAndRate)
                 .HasForeignKey(f2 => f2.UserId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Rate).HasDefaultValue(null);
            builder.Property(x => x.State).HasDefaultValue(false);
        
        }
    }

}
