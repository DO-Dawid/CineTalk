using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBase.Web.Data.Entities;

public class Movie
{
    public required string MovieId { get; set; } // wybór typu string dla klucza głównego jest arbitralny
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime ReleaseDate { get; set; }
    public required string Director { get; set; }
}

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(x => x.MovieId);
        builder.Property(x => x.MovieId).HasMaxLength(36);
        builder.Property(x => x.Title).HasMaxLength(256).UseCollation("NOCASE");
        builder.Property(x => x.Description).HasMaxLength(1024);
        builder.Property(x => x.Director).HasMaxLength(128);

        
        builder.HasData(
            new Movie
            {
                MovieId = "1516a394-4d9b-4447-a3ab-790a1c65b736",
                Title = "The Shawshank Redemption",
                Description =
                    "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ReleaseDate = new DateTime(1994, 9, 22),
                Director = "Frank Darabont"
            },
            new Movie
            {
                MovieId = "36f4836a-5e13-4c2f-96a6-f1f900754a94",
                Title = "The Godfather",
                Description =
                    "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                ReleaseDate = new DateTime(1972, 3, 24),
                Director = "Francis Ford Coppola"
            },
            new Movie
            {
                MovieId = "5f8de33b-ec39-4a46-ae1f-72b1faf04bed",
                Title = "The Dark Knight",
                Description =
                    "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                ReleaseDate = new DateTime(2008, 7, 18),
                Director = "Christopher Nolan"
            },
            new Movie
            {
                MovieId = "d261b91c-9dae-4ef7-a6ec-cc4d958b4357",
                Title = "Pulp Fiction",
                Description =
                    "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                ReleaseDate = new DateTime(1994, 10, 14),
                Director = "Quentin Tarantino"
            },
            new Movie
            {
                MovieId = "dd8b0905-b4ae-4264-a830-320fbee65e96",
                Title = "Forrest Gump",
                Description =
                    "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75.",
                ReleaseDate = new DateTime(1994, 7, 6),
                Director = "Robert Zemeckis"
            }
        );
    }
}