using BreederBlazor.Models.Base;
using BreederBlazor.Models.Dtos.LitterDto;
using BreederBlazor.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BreederBlazor.Services.Litters
{
    public class LitterService : ILitterService
    {
        private readonly HttpClient Http;
        private readonly IConfiguration config;
        private string ApiUrl;

        public LitterService(HttpClient _http, IConfiguration _config)
        {
            Http = _http;
            config = _config;
            ApiUrl = config.GetSection("api").Value;
        }

        public async Task<List<Litter>> CreateLitter(CreateLitterDto newLitter, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.PostAsJsonAsync<CreateLitterDto>(ApiUrl + "/Litter", newLitter);

            ServiceResponse<List<Litter>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Litter>>>();

            return content.Data;
        }

        public async Task<List<Litter>> DeleteLitter(int id, string key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Litter>> GetAllLitters(string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync(ApiUrl + "/Litter");

            ServiceResponse<List<Litter>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Litter>>>();

            return content.Data;
        }

        public async Task<Litter> GetLitterById(int id, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync(ApiUrl + "/Litter/" + id.ToString());

            ServiceResponse<Litter> content = await response.Content.ReadFromJsonAsync<ServiceResponse<Litter>>();

            return content.Data;
        }

        public async Task<Litter> UpdateLitter(UpdateLitterDto updatedLitter, string key)
        {
            throw new NotImplementedException();
        }
    }
}
