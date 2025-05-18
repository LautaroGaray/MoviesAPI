using Microsoft.AspNetCore.Mvc;

namespace MoviesAPI.Models
{
    public class ApiRequestModel
    {
        public string? BaseUrl { get; set; }
        public string? Endpoint { get; set; }
        public HttpMethod? HttpMethod { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string? Body { get; set; }
        public ApiRequestModel()
        {
            Headers = new Dictionary<string, string>();
        }
    }
}
