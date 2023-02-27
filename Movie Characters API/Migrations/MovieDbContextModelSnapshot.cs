﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie_Characters_API.Models;

#nullable disable

namespace Movie_Characters_API.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("MovieId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CharacterId = 1
                        },
                        new
                        {
                            MovieId = 1,
                            CharacterId = 2
                        },
                        new
                        {
                            MovieId = 3,
                            CharacterId = 3
                        });
                });

            modelBuilder.Entity("Movie_Characters_API.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Iron Man",
                            Gender = "Man",
                            Name = "Anthony Edward",
                            PictureUrl = "https://s3-us-west-2.amazonaws.com/forgefiction/wiki-pages-photos-test/image_anthony-edward-tony-stark-29WfBUfull.jpeg?hash=1588261380-344802"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "The Hulk",
                            Gender = "Man",
                            Name = "Robert Bruce Banner",
                            PictureUrl = "https://static.wikia.nocookie.net/transformerstopmotion/images/3/37/Bruce_Banner_Hulk_Avengers.png/revision/latest?cb=20140306034833"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Frodo Bagger",
                            Gender = "Man",
                            Name = "Elijah Wood",
                            PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTM0NDIxMzQ5OF5BMl5BanBnXkFtZTcwNzAyNTA4Nw@@._V1_.jpg"
                        });
                });

            modelBuilder.Entity("Movie_Characters_API.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Franchises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "The Marvel Cinematic Universe contains 23 movies",
                            Name = "Marvel"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Contains both the good trilogy and that other Hobbit one",
                            Name = "The Lord of the Rings"
                        });
                });

            modelBuilder.Entity("Movie_Characters_API.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TrailerUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "James Gunn",
                            FranchiseId = 1,
                            Genre = "Action, Fantasia",
                            PictureUrl = "https://m.media-amazon.com/images/M/MV5BMDgxOTdjMzYtZGQxMS00ZTAzLWI4Y2UtMTQzN2VlYjYyZWRiXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX1000_.jpg",
                            Title = "Avengers ",
                            TrailerUrl = "https://youtu.be/u3V5KDHRQvk",
                            Year = 2023
                        },
                        new
                        {
                            Id = 2,
                            Director = "Ryan Coogler",
                            FranchiseId = 1,
                            Genre = "Action , Fantasia",
                            PictureUrl = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/E9C4697F1745DEF68CD73B638BE6FCFB72B537788FB4F252E04B7BB745EE27A9/scale?width=1200&aspectRatio=1.78&format=jpeg",
                            Title = "Black Panther",
                            TrailerUrl = "https://youtu.be/xjDjIWPwcPU",
                            Year = 2022
                        },
                        new
                        {
                            Id = 3,
                            Director = "Peter Jackson",
                            FranchiseId = 2,
                            Genre = "Drama",
                            PictureUrl = "https://static.tvtropes.org/pmwiki/pub/images/868ad3d2_3a50_4a2a_8218_4fa10d1352b0.jpeg",
                            Title = "The Hobbit: An Unexpected Journey",
                            TrailerUrl = "https://youtu.be/SDnYMbYB-nU",
                            Year = 2012
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("Movie_Characters_API.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Movie_Characters_API.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Movie_Characters_API.Models.Movie", b =>
                {
                    b.HasOne("Movie_Characters_API.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("Movie_Characters_API.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
