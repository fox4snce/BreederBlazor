using BreederBlazor.Models.Base;
using BreederBlazor.Models.Dtos.NoteDto;
using BreederBlazor.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BreederBlazor.Services.Notes
{
    public class NoteService : INoteService
    {
        private readonly HttpClient Http;
        private readonly IConfiguration config;
        private string ApiUrl;

        public NoteService(HttpClient _http, IConfiguration _config)
        {
            Http = _http;
            config = _config;
            ApiUrl = config.GetSection("api").Value;
        }

        public async Task<List<Note>> CreateNote(CreateNoteDto newNote, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.PostAsJsonAsync<CreateNoteDto>(ApiUrl + "/Note", newNote);

            ServiceResponse<List<Note>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Note>>>();

            return content.Data;
        }

        public async Task<List<Note>> DeleteNote(int id, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.DeleteAsync(ApiUrl + "/Note/" + id);

            ServiceResponse<List<Note>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Note>>>();

            return content.Data;
        }

        public async Task<List<Note>> GetAllNotes(string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync(ApiUrl + "/Note");

            ServiceResponse<List<Note>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Note>>>();

            return content.Data;
        }

        public async Task<Note> GetNoteById(string key, int id)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync(ApiUrl + "/Note/ " + id.ToString());

            ServiceResponse<Note> content = await response.Content.ReadFromJsonAsync<ServiceResponse<Note>>();

            return content.Data;
        }

        public async Task<Note> UpdateNote(UpdateNoteDto updatedNote, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.PutAsJsonAsync<UpdateNoteDto>(ApiUrl + "/Note", updatedNote);

            ServiceResponse<Note> content = await response.Content.ReadFromJsonAsync<ServiceResponse<Note>>();

            return content.Data;
        }
    }
}
