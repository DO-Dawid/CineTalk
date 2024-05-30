using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieBase.Api.Endpoints;
using MovieBase.Web.Services;

namespace MovieBase.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MovieApiService _api;

    public IndexModel(ILogger<IndexModel> logger, MovieApiService api)
    {
        _logger = logger;
        _api = api;
    }

    public IEnumerable<ResponseMovie> Movies { get; set; }
    public void OnGet(string q)
    {
        Movies = _api.SearchMovies(q);
    }
}