using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Movie_Characters_API.Models
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } 
        public DbSet<Franchise> Franchises { get; set; } 
        public DbSet<Character> Characters { get; set; } 

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Franchise>().HasData(
            new Franchise { Id = 1, Name = "Marvel", Description = "The Marvel Cinematic Universe contains 23 movies" },
            new Franchise { Id = 2, Name = "The Lord of the Rings", Description = "Contains both the good trilogy and that other Hobbit one" }
            ); modelBuilder.Entity<Character>().HasData(
            new Character { Id = 1, Name = "Anthony Edward", Alias = "Iron Man", Gender = "Man", PictureUrl = "https://s3-us-west-2.amazonaws.com/forgefiction/wiki-pages-photos-test/image_anthony-edward-tony-stark-29WfBUfull.jpeg?hash=1588261380-344802" },
            new Character { Id = 2, Name = "Robert Bruce Banner", Alias = "The Hulk", Gender = "Man", PictureUrl = "https://static.wikia.nocookie.net/transformerstopmotion/images/3/37/Bruce_Banner_Hulk_Avengers.png/revision/latest?cb=20140306034833" },
            new Character { Id = 3, Name = "Elijah Wood", Alias = "Frodo Bagger", Gender = "Man", PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTM0NDIxMzQ5OF5BMl5BanBnXkFtZTcwNzAyNTA4Nw@@._V1_.jpg" }
            ); modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Avengers ", Genre = "Action, Fantasia", Year = 2023, Director = "James Gunn", PictureUrl = "https://m.media-amazon.com/images/M/MV5BMDgxOTdjMzYtZGQxMS00ZTAzLWI4Y2UtMTQzN2VlYjYyZWRiXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_FMjpg_UX1000_.jpg", TrailerUrl = "https://youtu.be/u3V5KDHRQvk", FranchiseId = 1 },
            new Movie { Id = 2, Title = "Black Panther", Genre = "Action , Fantasia", Year = 2022, Director = "Ryan Coogler", PictureUrl = "https://prod-ripcut-delivery.disney-plus.net/v1/variant/disney/E9C4697F1745DEF68CD73B638BE6FCFB72B537788FB4F252E04B7BB745EE27A9/scale?width=1200&aspectRatio=1.78&format=jpeg", TrailerUrl = "https://youtu.be/xjDjIWPwcPU", FranchiseId = 1 },
            new Movie { Id = 3, Title = "The Hobbit: An Unexpected Journey", Genre = "Drama", Year = 2012, Director = "Peter Jackson", PictureUrl = "https://static.tvtropes.org/pmwiki/pub/images/868ad3d2_3a50_4a2a_8218_4fa10d1352b0.jpeg", TrailerUrl = "https://youtu.be/SDnYMbYB-nU", FranchiseId = 2 }
            );

            modelBuilder.Entity<Movie>()
                .HasMany(p => p.Characters)
                .WithMany(m => m.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMovie",
                    r => r.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    l => l.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("MovieId", "CharacterId");
                        je.HasData(
                            new { MovieId = 1, CharacterId = 1 },
                            new { MovieId = 1, CharacterId = 2 },
                            new { MovieId = 3, CharacterId = 3 }
                        );
                    });
        }

    }
}
