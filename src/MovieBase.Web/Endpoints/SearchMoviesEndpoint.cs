using Microsoft.AspNetCore.Mvc;

namespace MovieBase.Web.Endpoints;

public static class SearchMoviesEndpoint
{
    private static Response[] _movies =
    [
        new Response("The Shawshank Redemption",
            "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
            new DateTime(1994, 9, 23),
            "Frank Darabont",
            9.3f),
        new Response("The Godfather",
            "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
            new DateTime(1972, 3, 24),
            "Francis Ford Coppola",
            9.2f),
        new Response("The Dark Knight",
            "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
            new DateTime(2008, 7, 18),
            "Christopher Nolan",
            9.0f),
        new Response("Schindler's List",
            "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
            new DateTime(1994, 2, 4),
            "Steven Spielberg",
            8.9f),
        new Response("Pulp Fiction",
            "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
            new DateTime(1994, 10, 14),
            "Quentin Tarantino",
            8.9f),
        new Response("The Lord of the Rings: The Return of the King",
            "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
            new DateTime(2003, 12, 17),
            "Peter Jackson",
            8.9f),
        new Response("Fight Club",
            "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
            new DateTime(1999, 10, 15),
            "David Fincher",
            8.8f),
        new Response("Forrest Gump",
            "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.",
            new DateTime(1994, 7, 6),
            "Robert Zemeckis",
            8.8f),
        new Response("Inception",
            "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
            new DateTime(2010, 7, 16),
            "Christopher Nolan",
            8.7f),
        new Response("The Matrix",
            "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
            new DateTime(1999, 3, 31),
            "The Wachowskis",
            8.7f)
    ];

    public static void Map(WebApplication app)
    {
        app.MapGet("/movies",
                ([FromQuery] string q) => _movies
                    .Where(x => x.Title.Contains(q, StringComparison.InvariantCultureIgnoreCase))
                    .OrderBy(x => x.Title)
                    .Take(10))
            .WithName("SearchMovies")
            .WithOpenApi();
    }

    private record Response(
        string Title,
        string Description,
        DateTime ReleaseDate,
        string Director,
        float AvgRating
    );
}