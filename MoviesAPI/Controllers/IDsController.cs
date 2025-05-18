using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Mapper;
using MoviesAPI.Models;
using MoviesAPI.Services;
using MoviesAPI.Services.interfaces;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IDsController : Controller
    {
        private readonly IApiService _apiService;

        private readonly IConfiguration _configuration;

        private readonly IMovieMapper _movieMapper;
        public IDsController(IApiService apiService, IConfiguration configuration, IMovieMapper movieMapper)
        {
            _apiService = apiService;
            _configuration = configuration;
            _movieMapper = movieMapper;
        }

        [HttpGet("/getGendersId")]
        public async Task<IActionResult> GetGenderId()
        {
            try
            {
                var idService = new IDsService(_apiService, _configuration, _movieMapper);
                return Ok(new Response {  Data = await idService.GetGendersId(), isSuccess = true });

            }catch(Exception ex)
            {
                return Ok(new Response { Code = 400, Message = "Error inIDs controller GET GENDER: "+ex.Message, isSuccess = false });
            }
        }
    }
}
