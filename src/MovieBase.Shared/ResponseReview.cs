namespace MovieBase.Api.Endpoints;

public record ResponseReview(
    string ReviewId,
    string ReviewerName,
    DateTime ReviewDate,
    string ReviewDetail,
    float Rating
);