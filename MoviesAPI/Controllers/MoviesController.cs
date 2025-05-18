using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Services;
using MoviesAPI.Services.interfaces;
using System.Net;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IApiService _apiService;

        private readonly IConfiguration _configuration;

        private readonly IMovieMapper _movieMapper;
        public MoviesController(IApiService apiService, IConfiguration configuration, IMovieMapper movieMapper)
        {
            _apiService = apiService;
            _configuration = configuration;
            _movieMapper = movieMapper;
        }

        [HttpGet("/getPopularMovies")]
        public async  Task<IActionResult> GetPopular()
        {
            try
            {
                var movieService = new MovieService(_apiService, _configuration, _movieMapper);
                return Ok( new Response { isSuccess = true, Data = await movieService.GetPopular(), Message = "" });
            }
            catch (Exception ex)
            {
                return Ok(new Response { isSuccess = false, Code = 400, Message = "Exception in movieController GET POPULAR: "+ex.Message });
            }
        }
    }
}
