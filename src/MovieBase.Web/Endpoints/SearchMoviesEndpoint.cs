using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBase.Web.Data;

namespace MovieBase.Web.Endpoints;

public static class SearchMoviesEndpoint
{

    public static void Map(WebApplication app)
    {
        app.MapGet("/movies",
                ([FromQuery] string? q, MovieBaseContext context) =>
                {
                    if (string.IsNullOrWhiteSpace(q))
                    {
                        return context.Movies
                            .OrderBy(m => m.Title)
                            .Take(10)
                            .Select(x => new Response(
                                x.MovieId,
                                x.Title,
                                x.Description,
                                x.ReleaseDate,
                                x.Director,
                                0
                            ));
                    }
                    return context.Movies
                        .Where(m => EF.Functions.Like(m.Title, $"%{q}%"))
                        .OrderBy(m => EF.Functions.Like(m.Title, q) ? 0 : 1) // Exact matches first
                        .ThenBy(m => m.Title.Length) // Finally by the length of the title
                        .Take(10)
                        .Select(x => new Response(
                            x.MovieId,
                            x.Title,
                            x.Description,
                            x.ReleaseDate,
                            x.Director,
                            0
                        ));
                }
                )
            .WithName("SearchMovies")
            .WithOpenApi();
    }

    private record Response(
        string MovieId,
        string Title,
        string Description,
        DateTime ReleaseDate,
        string Director,
        float AvgRating
    );
}