using Microsoft.AspNetCore.Mvc;
using MovieBase.Web.Data;
using MovieBase.Web.Data.Entities;

namespace MovieBase.Web.Endpoints;

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
                        x.Rating
                    ));
            }
            )
            .WithName("ShowReviews")
            .WithOpenApi();
    }

    private record ResponseReview(
        string ReviewId,
        string ReviewerName,
        DateTime ReviewDate,
        float Rating
    );
}