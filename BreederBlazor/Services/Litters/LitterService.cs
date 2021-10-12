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

namespace BreederBlazor.Services.Litters
{
    public class LitterService : ILitterService
    {
        private readonly HttpClient Http;

        public LitterService(HttpClient _http)
        {
            Http = _http;
        }

        public async Task<List<Litter>> CreateLitter(CreateLitterDto newLitter, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.PostAsJsonAsync<CreateLitterDto>("http://localhost:5050/Litter", newLitter);

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

            var response = await Http.GetAsync("http://localhost:5050/Litter");

            ServiceResponse<List<Litter>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Litter>>>();

            return content.Data;
        }

        public async Task<Litter> GetLitterById(int id, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync("http://localhost:5050/Litter/" + id.ToString());

            ServiceResponse<Litter> content = await response.Content.ReadFromJsonAsync<ServiceResponse<Litter>>();

            return content.Data;
        }

        public async Task<Litter> UpdateLitter(UpdateLitterDto updatedLitter, string key)
        {
            throw new NotImplementedException();
        }
    }
}
