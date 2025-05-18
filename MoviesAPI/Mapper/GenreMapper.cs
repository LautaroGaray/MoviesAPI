using MoviesAPI.Models.Dto;
using System.Text.Json;

namespace MoviesAPI.Mapper
{
    public class GenreMapper
    {
        public static List<GenreDto> MapGenresFromJson(string json)
        {
            var genreDtos = new List<GenreDto>();
            var document = JsonDocument.Parse(json);

            var genres = document.RootElement.GetProperty("genres");

            foreach (var genreJson in genres.EnumerateArray())
            {
                genreDtos.Add(new GenreDto
                {
                    Id = genreJson.GetProperty("id").GetInt32(),
                    Name = genreJson.GetProperty("name").GetString() ?? string.Empty
                });
            }

            return genreDtos;
        }
    }
}
