namespace MoviesAPI.Models.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public string PosterPath { get; set; } = string.Empty;
        public double VoteAverage { get; set; }
        public List<GenreData> Genres { get; set; } = new();
        public List<int> CastIds { get; set; } = new(); // esto lo llenás si consultas el cast

        public double Popularity { get; set; }
    }

    public class GenreData 
    { 
        public int GenreId { get; set; }
        public string Genre { get; set; }
    }

}


