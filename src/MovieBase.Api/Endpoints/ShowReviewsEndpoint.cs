using Microsoft.AspNetCore.Mvc;
using MovieBase.Api.Data;
using MovieBase.Api.Data.Entities;

namespace MovieBase.Api.Endpoints;

public class ShowReviewsEndpoint
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/movies/{movieId}/reviews",
            (string movieId, MovieBaseContext context) =>
            {
                return context.Reviews
                    .Where(r => r.MovieId == movieId)
                    .OrderBy(r => r.ReviewDate)
                    .Select(x => new ResponseReview(
                        x.ReviewId,
                        x.ReviewerName,
                        x.ReviewDate,
                        x.ReviewDetail,
                        x.Rating
                    ));
            }
            )
            .WithName("ShowReviews")
            .WithOpenApi();
    }
}