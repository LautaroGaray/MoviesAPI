namespace MoviesAPI.Models
{
    public class Response
    {
        public int Code { get; set; } = 200;
        public string? Message { get; set; } = "";
        public bool isSuccess { get; set; }
        public object? Data { get; set; }
    }
}
