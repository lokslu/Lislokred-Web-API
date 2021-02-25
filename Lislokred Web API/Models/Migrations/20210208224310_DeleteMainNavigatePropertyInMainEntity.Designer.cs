﻿// <auto-generated />
using System;
using Lislokred_Web_API.Models.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lislokred_Web_API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210208224310_DeleteMainNavigatePropertyInMainEntity")]
    partial class DeleteMainNavigatePropertyInMainEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.FilmingUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FilmingUnits");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Data")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.ImageMovie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlData")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("MovieId");

                    b.ToTable("ImageMovies");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.ImageUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UrlData")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UnitId");

                    b.ToTable("ImageUnit");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.ImageUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("ImageUser");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FilmingUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmingUnitId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.MovieToGenre", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GanreId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "GanreId");

                    b.HasIndex("GanreId");

                    b.HasIndex("MovieId", "GanreId")
                        .IsUnique();

                    b.ToTable("MovieToGenre");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.Ratio", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FilmUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Актёр");

                    b.HasKey("MovieId", "FilmUnitId");

                    b.HasIndex("FilmUnitId");

                    b.HasIndex("MovieId", "FilmUnitId")
                        .IsUnique();

                    b.ToTable("Ratio");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.StateAndRate", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("MovieId", "UserId");

                    b.HasIndex("UserId");

                    b.HasIndex("MovieId", "UserId")
                        .IsUnique();

                    b.ToTable("StateAndRate");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.UserToGenre", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GanreId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "GanreId");

                    b.HasIndex("GanreId");

                    b.HasIndex("UserId", "GanreId")
                        .IsUnique();

                    b.ToTable("UserToGenre");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.ImageMovie", b =>
                {
                    b.HasOne("Lislokred_Web_API.Models.Entitys.Movie", "Movie")
                        .WithMany("ImageMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.ImageUnit", b =>
                {
                    b.HasOne("Lislokred_Web_API.Models.Entitys.FilmingUnit", "Unit")
                        .WithMany("ImagesUnit")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.ImageUser", b =>
                {
                    b.HasOne("Lislokred_Web_API.Models.Entitys.User", "User")
                        .WithMany("ImageUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.Movie", b =>
                {
                    b.HasOne("Lislokred_Web_API.Models.Entitys.FilmingUnit", null)
                        .WithMany("Movies")
                        .HasForeignKey("FilmingUnitId");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.MovieToGenre", b =>
                {
                    b.HasOne("Lislokred_Web_API.Models.Entitys.Genre", "Ganre")
                        .WithMany("MovieToGenre")
                        .HasForeignKey("GanreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lislokred_Web_API.Models.Entitys.Movie", "Movie")
                        .WithMany("MovieToGenre")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ganre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.Ratio", b =>
                {
                    b.HasOne("Lislokred_Web_API.Models.Entitys.FilmingUnit", "FilmUnit")
                        .WithMany("Ratios")
                        .HasForeignKey("FilmUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lislokred_Web_API.Models.Entitys.Movie", "Movie")
                        .WithMany("Ratios")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmUnit");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.StateAndRate", b =>
                {
                    b.HasOne("Lislokred_Web_API.Models.Entitys.Movie", "Movie")
                        .WithMany("StateAndRate")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lislokred_Web_API.Models.Entitys.User", "User")
                        .WithMany("StateAndRate")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.UserToGenre", b =>
                {
                    b.HasOne("Lislokred_Web_API.Models.Entitys.Genre", "Ganre")
                        .WithMany("UserToGenre")
                        .HasForeignKey("GanreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lislokred_Web_API.Models.Entitys.User", "User")
                        .WithMany("UserToGenre")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ganre");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.FilmingUnit", b =>
                {
                    b.Navigation("ImagesUnit");

                    b.Navigation("Movies");

                    b.Navigation("Ratios");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.Genre", b =>
                {
                    b.Navigation("MovieToGenre");

                    b.Navigation("UserToGenre");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.Movie", b =>
                {
                    b.Navigation("ImageMovies");

                    b.Navigation("MovieToGenre");

                    b.Navigation("Ratios");

                    b.Navigation("StateAndRate");
                });

            modelBuilder.Entity("Lislokred_Web_API.Models.Entitys.User", b =>
                {
                    b.Navigation("ImageUsers");

                    b.Navigation("StateAndRate");

                    b.Navigation("UserToGenre");
                });
#pragma warning restore 612, 618
        }
    }
}
