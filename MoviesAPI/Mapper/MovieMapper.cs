using MoviesAPI.Models.Dto;
using System.Text.Json;

namespace MoviesAPI.Mapper
{
   

    public static class MovieMapper
    {
        public static MovieDto MapFromJson(JsonElement json)
        {
            var dto = new MovieDto
            {
                Id = json.GetProperty("id").GetInt32(),
                Title = json.GetProperty("title").GetString() ?? string.Empty,
                Overview = json.GetProperty("overview").GetString() ?? string.Empty,
                PosterPath = json.GetProperty("poster_path").GetString() ?? string.Empty,
                VoteAverage = json.GetProperty("vote_average").GetDouble(),
                Popularity = json.GetProperty("popularity").GetDouble(),

               
                Genres = json.TryGetProperty("genre_ids", out var genreArray)
                           ? genreArray.EnumerateArray().Select(x => new GenreData
                           {
                               GenreId = x.GetInt32(),
                               Genre = string.Empty 
                           }).ToList()
                           : new List<GenreData>(),

                CastIds = new List<int>() 
            };

            return dto;
        }
    }

}
