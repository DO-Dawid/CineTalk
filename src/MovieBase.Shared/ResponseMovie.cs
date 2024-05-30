namespace MovieBase.Api.Endpoints;

public record ResponseMovie(
    string MovieId,
    string Title,
    string Description,
    DateTime ReleaseDate,
    string Director,
    float? AvgRating
);