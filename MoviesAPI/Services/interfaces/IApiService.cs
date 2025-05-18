using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Services.interfaces
{
    public interface IApiService
    {
        void Initializate();
        Task<string> MakeApiRequestAsync(ApiRequestModel config);
    }
}
