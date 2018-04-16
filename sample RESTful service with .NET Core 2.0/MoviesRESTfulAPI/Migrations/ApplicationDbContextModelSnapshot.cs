﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MoviesRESTfulAPI.DAL;
using System;

namespace MoviesRESTfulAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesRESTfulAPI.Models.Actors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio")
                        .IsRequired();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("MoviesRESTfulAPI.Models.Genre", b =>
                {
                    b.Property<byte>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MoviesRESTfulAPI.Models.MovieActors", b =>
                {
                    b.Property<int>("ActorsId");

                    b.Property<int>("MoviesId");

                    b.HasKey("ActorsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("MovieActors");
                });

            modelBuilder.Entity("MoviesRESTfulAPI.Models.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte>("AvailableInStock");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<byte>("GenreId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte>("NumberInStock");

                    b.Property<DateTime>("ReleaseDate");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesRESTfulAPI.Models.MovieActors", b =>
                {
                    b.HasOne("MoviesRESTfulAPI.Models.Actors", "Actors")
                        .WithMany()
                        .HasForeignKey("ActorsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MoviesRESTfulAPI.Models.Movies", "Movies")
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoviesRESTfulAPI.Models.Movies", b =>
                {
                    b.HasOne("MoviesRESTfulAPI.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}