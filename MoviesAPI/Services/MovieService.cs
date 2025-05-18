using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Services.interfaces;

namespace MoviesAPI.Services
{
    public class MovieService
    {
        private readonly IApiService _apiService;

        private readonly IConfiguration _configuration;

        private readonly IMovieMapper _movieMapper;
        public MovieService(IApiService apiService, IConfiguration configuration, IMovieMapper movieMapper)
        {
            _apiService = apiService;
            _configuration = configuration;
            _movieMapper = movieMapper;
        }

        public async Task<List<Models.Dto.MovieDto>> GetPopular()
        {
            try
            {
                var token = _configuration["Token"];
                var baseUrl = _configuration["TMDB_Url"];
                ApiRequestModel reqModel = new ApiRequestModel();
                reqModel.Endpoint = baseUrl + MovieEndpoints.GetPopularSpanish;
                reqModel.HttpMethod = HttpMethod.Get;
                reqModel.Headers = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer "+token}
                };

                _apiService.Initializate();
                var response = await _apiService.MakeApiRequestAsync(reqModel);
                var movieMapped = _movieMapper.MapMovieToDto(response);
                var idService = new IDsService(_apiService, _configuration, _movieMapper);

                if (movieMapped.Count == 0)
                    throw new Exception("No se han encontrado peliculas..");

                try
                {
                    var genres = await idService.GetGendersId();
                    if (genres.Count > 0)
                    {
                       foreach(var movie in movieMapped)
                       {

                            foreach (var genre in movie.Genres)
                            {
                                var genreName = genres.FirstOrDefault(g => g.Id == genre.GenreId)?.Name;
                                genre.Genre = !string.IsNullOrEmpty(genreName) ? genreName : "";                                
                               
                            }

                        }
                    }
                }
                catch(Exception ex){}
               

                return movieMapped;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
