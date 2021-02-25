using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lislokred_Web_API.Models.Entitys
{

    public class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<FilmingUnit> FilmingUnits { get; set; }

        public DbSet<ImageMovie> ImageMovies { get; set; }
        public DbSet<ImageUser> ImageUser { get; set; }
        public DbSet<ImageUnit> ImageUnit { get; set; }

        public DbSet<UserToGenre> UserToGenre { get; set; }
        public DbSet<MovieToGenre> MovieToGenre { get; set; }
        public DbSet<StateAndRate> StateAndRate { get; set; }
        public DbSet<Ratio> Ratio { get; set; }




        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            // Database.EnsureDeleted();   // удаляем бд со старой схемой
            // Database.EnsureCreated();   // создаем бд с новой схемой
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            /*жанр*/

            //modelBuilder.Entity<Genre>()
            //    .HasMany(gc => gc.Users)
            //    .WithMany(gs => gs.FavoriteGenres)

            //    .UsingEntity<UserToGenre>(
            //    gj => gj
            //    .HasOne(gp => gp.User)
            //    .WithMany(gts => gts.UserToGenre)
            //    .HasForeignKey(gfk => gfk.UserId),
            //    gj => gj
            //    .HasOne(gp => gp.Ganre)
            //    .WithMany(gt => gt.UserToGenre)
            //    .HasForeignKey(gfk => gfk.GanreId),
            //     gj =>
            //     {
            //         gj.HasKey(t => new { t.GanreId, t.UserId });
            //         gj.Property(pt => pt.IsFavorite).HasDefaultValue(false);
            //         gj.ToTable("UserToGenre");
            //     }
            //     )
            //     .HasMany(gc => gc.Movies)
            //    .WithMany(gs => gs.Ganres)

            //    .UsingEntity<MovieToGenre>(
            //    gj => gj
            //    .HasOne(gp => gp.Movie)
            //    .WithMany(gts => gts.MovieToGenre)
            //    .HasForeignKey(gfk => gfk.MovieId),
            //    gj => gj
            //    .HasOne(gp => gp.Ganre)
            //    .WithMany(gt => gt.MovieToGenre)
            //    .HasForeignKey(gfk => gfk.GanreId),
            //     gj =>
            //     {
            //         gj.HasKey(t => new { t.GanreId, t.MovieId });
            //         gj.ToTable("MovieToGenre");
            //     }
            //     ); ;


            //юсер
            //modelBuilder.Entity<User>()
            //        .HasMany(c => c.MyWatchMovie)
            //        .WithMany(s => s.Users)

            //        .UsingEntity<StateAndRate>(j => j
            //        .HasOne(ps => ps.Movie)
            //        .WithMany(t => t.StateAndRate)
            //        .HasForeignKey(pt => pt.MovieId),
            //        j => j
            //        .HasOne(ps => ps.User)
            //        .WithMany(t => t.StateAndRate)
            //        .HasForeignKey(pt => pt.UserId),
            //        j =>
            //        {
            //            j.Property(pt => pt.Rate).HasDefaultValue(0);
            //            j.Property(pt => pt.State).HasDefaultValue(false);
            //            j.HasKey(t => new { t.MovieId, t.UserId });
            //            j.ToTable("StatesAndRates");
            //        }
            //        );

            //фильм
            //modelBuilder.Entity<Movie>()
            //        .HasMany(c => c.FilmСrew)
            //        .WithMany(s => s.Movies)

            //        .UsingEntity<Ratio>(j => j
            //        .HasOne(ps => ps.FilmUnit)
            //        .WithMany(t => t.Ratios)
            //        .HasForeignKey(pt => pt.FilmUnitId),
            //        j => j
            //        .HasOne(ps => ps.Movie)
            //        .WithMany(t => t.Ratios)
            //        .HasForeignKey(pt => pt.MovieId),
            //        j =>
            //        {
            //            j.Property(pt => pt.Role).HasDefaultValue("Actor");
            //            j.HasKey(t => new { t.MovieId, t.FilmUnitId });
            //            j.ToTable("Roles");
            //        }
            //        );

            //картинки 
            //modelBuilder.Entity<ImageMovie>()
            //    .HasOne(p => p.Movie)
            //    .WithMany(pt => pt.ImageMovies)
            //    .HasForeignKey(fk => fk.MovieId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ImageUnit>()
            //    .HasOne(p => p.Unit)
            //    .WithMany(pt => pt.ImagesUnit)
            //    .HasForeignKey(fk => fk.UnitId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<ImageUser>()
            //    .HasOne(p => p.User)
            //    .WithMany(pt => pt.ImageUsers)
            //    .HasForeignKey(fk => fk.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }

}
