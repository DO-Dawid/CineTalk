using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieBase.Api.Data;
using MovieBase.Api.Data.Entities;

namespace MovieBase.Api.Endpoints;

public class DeleteReviewEndpoint
{
    public static void Map(WebApplication app)
    {
        app.MapDelete("movies/{movieId}/reviews/{reviewId}", async (string movieId, string reviewId, MovieBaseContext context) =>
        {
            var review = await context.Reviews.FirstOrDefaultAsync(r => r.MovieId == movieId && r.ReviewId == reviewId);
            if (review == null)
            {
                return Results.NotFound("Review not found");
            }

            context.Reviews.Remove(review);
            await context.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}