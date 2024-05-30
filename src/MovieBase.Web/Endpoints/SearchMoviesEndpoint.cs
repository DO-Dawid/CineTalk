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
                            .Select(x => new ResponseMovie(
                                x.MovieId,
                                x.Title,
                                x.Description,
                                x.ReleaseDate,
                                x.Director,
                                context.Reviews.Any(r => r.MovieId == x.MovieId)
                                    ? context.Reviews.Where(r => r.MovieId == x.MovieId).Average(r => r.Rating)
                                    : null
                            ));
                    }

                    return context.Movies
                        .Where(m => EF.Functions.Like(m.Title, $"%{q}%"))
                        .OrderBy(m => EF.Functions.Like(m.Title, q) ? 0 : 1) // Exact matches first
                        .ThenBy(m => m.Title.Length) // Finally by the length of the title
                        .Take(10)
                        .Select(x => new ResponseMovie(
                            x.MovieId,
                            x.Title,
                            x.Description,
                            x.ReleaseDate,
                            x.Director,
                            context.Reviews.Any(r => r.MovieId == x.MovieId)
                                ? context.Reviews.Where(r => r.MovieId == x.MovieId).Average(r => r.Rating)
                                : null
                        ));
                }
            )
            .WithName("SearchMovies")
            .WithOpenApi();
    }

    private record ResponseMovie(
        string MovieId,
        string Title,
        string Description,
        DateTime ReleaseDate,
        string Director,
        float? AvgRating
    );
}