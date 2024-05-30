using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBase.Web.Data;
using MovieBase.Web.Data.Entities;

namespace MovieBase.Web.Endpoints;

public class AddReviewEndpoint
{
    public static void Map(WebApplication app)
    {
        app.MapPost("movies/{movieId}/reviews",
            (string movieId, [FromBody] RequestReview req, MovieBaseContext context) =>
            {
                if (!context.Movies.Any(x=>x.MovieId == movieId))
                {
                    return Results.BadRequest("Movie not found");
                }

                if (req.Rating is < 0 or > 5)
                {
                    return Results.BadRequest("Rating must be between 0 - 5");
                }

                context.Reviews.Add(new Review
                {
                    MovieId = movieId,
                    ReviewerName = req.ReviewerName,
                    Rating = req.Rating,
                    ReviewDate = DateTime.Now,
                    ReviewId = Guid.NewGuid().ToString()
                });
                context.SaveChanges();
                return Results.Created();
            });
    }

    private record RequestReview(string ReviewerName, float Rating);
}