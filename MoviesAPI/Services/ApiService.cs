using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading.Tasks;
using MoviesAPI.Models;
using MoviesAPI.Services.interfaces;

namespace MoviesAPI.Business
{   

    public class ApiService :IApiService
    {
        private HttpClient _httpClient;

        public void Initializate()
        {
            this._httpClient = new HttpClient();
        }

        public async Task<string> MakeApiRequestAsync(ApiRequestModel config)
        {
            try
            {
                var request = new HttpRequestMessage(config.HttpMethod, config.BaseUrl+config.Endpoint);

                foreach (var header in config.Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }


                if (!string.IsNullOrEmpty(config.Body))
                {
                    request.Content = new StringContent(config.Body, Encoding.UTF8, "application/json");
                }


                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Exception in the Api hepler: " + ex.Message);
            }
           
        }
    }

}
