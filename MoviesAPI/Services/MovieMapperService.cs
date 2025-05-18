using MoviesAPI.Mapper;
using MoviesAPI.Models.Dto;
using MoviesAPI.Services.interfaces;
using System.Text.Json;

namespace MoviesAPI.Services
{
    public class MovieMapperService:IMovieMapper
    {
        public List<MovieDto> MapMovieToDto(string jsonResponse)
        {
            JsonDocument doc = JsonDocument.Parse(jsonResponse); // jsonResponse = el string completo
            var results = doc.RootElement.GetProperty("results");

            var movies = new List<MovieDto>();

            foreach (var movieJson in results.EnumerateArray())
            {
                var movieDto = MovieMapper.MapFromJson(movieJson);
                movies.Add(movieDto);
            }

            return movies;
        }

        public List<GenreDto> MapGenreToDto(string jsonResponse)
        {
            var genres = GenreMapper.MapGenresFromJson(jsonResponse);

            foreach (var genre in genres)
            {
                Console.WriteLine($"{genre.Id} - {genre.Name}");
            }
            return genres;
        }

    }
}
