using BreederBlazor.Models.Base;
using BreederBlazor.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BreederBlazor.Services.BreedingRecords
{
    public class BreedingRecordService : IBreedingRecordService
    {

        private readonly HttpClient Http;

        public BreedingRecordService(HttpClient _http)
        {
            Http = _http;
        }

        public async Task<List<BreedingRecord>> CreateBreedingRecord(BreedingRecord newBreedingRecord)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BreedingRecord>> DeleteBreedingRecord(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BreedingRecord>> GetAllBreedingRecords(string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync("http://localhost:5050/BreedingRecord");

            ServiceResponse<List<BreedingRecord>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<BreedingRecord>>>();

            return content.Data;
        }

        public async Task<BreedingRecord> GetBreedingRecordById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BreedingRecord> UpdateBreedingRecord(BreedingRecord updatedBreedingRecord)
        {
            throw new NotImplementedException();
        }
    }
}
