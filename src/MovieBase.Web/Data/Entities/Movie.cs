using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MovieBase.Web.Data.Entities;

public class Movie
{
    public required string MovieId { get; set; }
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
        builder.Property(x => x.Title).HasMaxLength(256).UseCollation("NOCASE");
        builder.Property(x => x.Description).HasMaxLength(1024);
        builder.Property(x => x.Director).HasMaxLength(128);

        builder.HasData(
            new Movie
            {
                MovieId = Guid.NewGuid().ToString(),
                Title = "The Shawshank Redemption",
                Description =
                    "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                ReleaseDate = new DateTime(1994, 9, 22),
                Director = "Frank Darabont"
            },
            new Movie
            {
                MovieId = Guid.NewGuid().ToString(),
                Title = "The Godfather",
                Description =
                    "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                ReleaseDate = new DateTime(1972, 3, 24),
                Director = "Francis Ford Coppola"
            },
            new Movie
            {
                MovieId = Guid.NewGuid().ToString(),
                Title = "The Dark Knight",
                Description =
                    "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                ReleaseDate = new DateTime(2008, 7, 18),
                Director = "Christopher Nolan"
            },
            new Movie
            {
                MovieId = Guid.NewGuid().ToString(),
                Title = "Pulp Fiction",
                Description =
                    "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                ReleaseDate = new DateTime(1994, 10, 14),
                Director = "Quentin Tarantino"
            },
            new Movie
            {
                MovieId = Guid.NewGuid().ToString(),
                Title = "Forrest Gump",
                Description =
                    "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other history unfold through the perspective of an Alabama man with an IQ of 75.",
                ReleaseDate = new DateTime(1994, 7, 6),
                Director = "Robert Zemeckis"
            }
        );
    }
}