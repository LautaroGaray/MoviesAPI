using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using MoviesAPI.Models.Dto;
using MoviesAPI.Services.interfaces;

namespace MoviesAPI.Services
{
    
    public class IDsService
    {
        private readonly IApiService _apiService;

        private readonly IConfiguration _configuration;


        private readonly IMovieMapper _movieMapper;
        public IDsService(IApiService apiService, IConfiguration configuration, IMovieMapper movieMapper)
        {
            _apiService = apiService;
            _configuration = configuration;
            _movieMapper = movieMapper;
        }

        public async Task<List<GenreDto>> GetGendersId()
        {
            try
            {
                var token = _configuration["Token"];
                var baseUrl = _configuration["TMDB_Url"];
                ApiRequestModel reqModel = new ApiRequestModel();
                reqModel.Endpoint = baseUrl + MovieEndpoints.GetGenreIds;
                reqModel.HttpMethod = HttpMethod.Get;
                reqModel.Headers = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer "+token}
                };

                _apiService.Initializate();
                var response = await _apiService.MakeApiRequestAsync(reqModel);
               

                return  _movieMapper.MapGenreToDto(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
