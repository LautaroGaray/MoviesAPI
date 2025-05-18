using MoviesAPI.Models.Dto;

namespace MoviesAPI.Services.interfaces
{
    public interface IMovieMapper
    {
        public List<MovieDto> MapMovieToDto(string jsonResponse);
        public List<GenreDto> MapGenreToDto(string jsonResponse);
    }
}
