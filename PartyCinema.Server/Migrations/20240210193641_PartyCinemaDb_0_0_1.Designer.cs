﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartyCinema.Server;

#nullable disable

namespace PartyCinema.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240210193641_PartyCinemaDb_0_0_1")]
    partial class PartyCinemaDb_0_0_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId")
                        .IsUnique();

                    b.HasIndex("MovieId");

                    b.HasIndex("VideoId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedRoomId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Season")
                        .HasColumnType("tinyint");

                    b.Property<byte>("Serie")
                        .HasColumnType("tinyint");

                    b.Property<long>("Views")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("RoomUser", b =>
                {
                    b.Property<int>("ViewRoomsId")
                        .HasColumnType("int");

                    b.Property<int>("ViewersId")
                        .HasColumnType("int");

                    b.HasKey("ViewRoomsId", "ViewersId");

                    b.HasIndex("ViewersId");

                    b.ToTable("RoomUser");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("PartyCinema.Server.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyCinema.Server.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Room", b =>
                {
                    b.HasOne("PartyCinema.Server.Models.User", "CreatedUser")
                        .WithOne("CreatedRoom")
                        .HasForeignKey("PartyCinema.Server.Models.Room", "CreatedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyCinema.Server.Models.Movie", "Movie")
                        .WithMany("Rooms")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyCinema.Server.Models.Video", "Video")
                        .WithMany("Rooms")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("Movie");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.User", b =>
                {
                    b.HasOne("PartyCinema.Server.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Video", b =>
                {
                    b.HasOne("PartyCinema.Server.Models.Movie", "Movie")
                        .WithMany("Videos")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("RoomUser", b =>
                {
                    b.HasOne("PartyCinema.Server.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("ViewRoomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartyCinema.Server.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ViewersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Movie", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.User", b =>
                {
                    b.Navigation("CreatedRoom");
                });

            modelBuilder.Entity("PartyCinema.Server.Models.Video", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
