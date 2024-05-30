using Flurl.Http;
using MovieBase.Api.Endpoints;

namespace MovieBase.Web.Services;

public class MovieApiService
{
    private readonly string _url;

    public MovieApiService(string url)
    {
        _url = url;
    }

    public IEnumerable<ResponseMovie> SearchMovies(string? q)
    {
        return $"{_url}/movies?q={q}".GetJsonAsync<IEnumerable<ResponseMovie>>().Result;
    }
    
    public IEnumerable<ResponseReview> GetMovieReviews(string movieId)
    {
        return $"{_url}/movies/{movieId}/reviews".GetJsonAsync<IEnumerable<ResponseReview>>().Result;
    }

    public void createReview(string movieId, RequestReview review)
    {
        $"{_url}/movies/{movieId}/reviews".PostJsonAsync(review).Wait();
    }
    
    public void DeleteReview(string movieId, string reviewId)
    {
        $"{_url}/movies/{movieId}/reviews/{reviewId}".DeleteAsync();
    }

}