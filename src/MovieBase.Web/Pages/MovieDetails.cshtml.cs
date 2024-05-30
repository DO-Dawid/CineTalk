using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieBase.Api.Endpoints;
using MovieBase.Web.Services;

namespace MovieBase.Web.Pages;

public class MovieDetails : PageModel
{
    private readonly MovieApiService _api;

    public MovieDetails(MovieApiService api)
    {
        _api = api;
    }

    public IEnumerable<ResponseReview> Reviews { get; set; }
    public void OnGet(string movieId)
    {
        MovieId = movieId;
        Reviews = _api.GetMovieReviews(movieId);
    }
    public void OnPost(string movieId)
    {
        _api.createReview(movieId, new RequestReview(ReviewerName, Details, Rating));
        OnGet(movieId);
    }
    public IActionResult OnPostDeleteReview(string movieId, string reviewId)
    {
        _api.DeleteReview(movieId, reviewId);
        return RedirectToPage(new { movieId });
    }

    public string MovieId { get; set; } = null!;
    
    [BindProperty]public string ReviewerName { get; set; }
    [BindProperty]public string Details { get; set; }
    [BindProperty]public float Rating { get; set; }
    
 
    
}