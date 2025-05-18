namespace MoviesAPI.Models
{
    public static class MovieEndpoints
    {
        public const string GetPopularSpanish = "/movie/popular?language=es-ES&page=1";
        public const string GetPopularEnglish = "/movie/popular?language=en-EN&page=1";
        public const string GetByMovieName = "/search/movie?language=es-ES&query={Reeplace}&page=1";
        public const string GetActorID = "/search/person?language=es-ES&query={Reeplace}";
        public const string GetMovieByActorID = "/discover/movie?language=es-ES&with_cast={Reeplace}&page=1";
        public const string GetGenreIds = "/genre/movie/list?language=es-ES";
        public const string GetByGenreId = "/discover/movie?language=es-ES&with_genres={Reeplace}&page=1";
    }

}
