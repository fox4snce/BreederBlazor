using BreederBlazor.Models.Base;
using BreederBlazor.Models.Dtos.BreedingRecordDto;
using BreederBlazor.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BreederBlazor.Services.BreedingRecords
{
    public class BreedingRecordService : IBreedingRecordService
    {

        private readonly HttpClient Http;
        private readonly IConfiguration config;
        private string ApiUrl;

        public BreedingRecordService(HttpClient _http, IConfiguration _config)
        {
            Http = _http;
            config = _config;
            ApiUrl = config.GetSection("api").Value;
        }

        public async Task<List<BreedingRecord>> CreateBreedingRecord(CreateBreedingRecordDto newBreedingRecord, string key)
        {
            

            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.PostAsJsonAsync<CreateBreedingRecordDto>(ApiUrl + "/BreedingRecord", newBreedingRecord);

            ServiceResponse<List<BreedingRecord>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<BreedingRecord>>>();

            return content.Data;
        }

        public async Task<List<BreedingRecord>> DeleteBreedingRecord(int id, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.DeleteAsync(ApiUrl + "/BreedingRecord/" + id);

            ServiceResponse<List<BreedingRecord>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<BreedingRecord>>>();

            return content.Data;
        }

        public async Task<List<BreedingRecord>> GetAllBreedingRecords(string key)
        {
            Console.WriteLine("Key: " + key);

            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync(ApiUrl + "/BreedingRecord");

            ServiceResponse<List<BreedingRecord>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<BreedingRecord>>>();

            return content.Data;
        }

        public async Task<BreedingRecord> GetBreedingRecordById(string key, int id)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync(ApiUrl + "/BreedingRecord/" + id.ToString());

            ServiceResponse<BreedingRecord> content = await response.Content.ReadFromJsonAsync<ServiceResponse<BreedingRecord>>();

            return content.Data;
        }

        public async Task<BreedingRecord> UpdateBreedingRecord(UpdateBreedingRecordDto updatedBreedingRecord, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.PutAsJsonAsync<UpdateBreedingRecordDto>(ApiUrl + "/BreedingRecord", updatedBreedingRecord);
            
            ServiceResponse<BreedingRecord> content = await response.Content.ReadFromJsonAsync<ServiceResponse<BreedingRecord>>();

            return content.Data;
        }
    }
}
