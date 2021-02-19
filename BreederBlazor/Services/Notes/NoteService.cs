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

namespace BreederBlazor.Services.Notes
{
    public class NoteService : INoteService
    {
        private readonly HttpClient Http;

        public NoteService(HttpClient _http)
        {
            Http = _http;
        }

        public async Task<List<Note>> CreateNote(CreateNoteDto newNote, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.PostAsJsonAsync<CreateNoteDto>("http://localhost:5050/Note", newNote);

            ServiceResponse<List<Note>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Note>>>();

            return content.Data;
        }

        public Task<List<Note>> DeleteNote(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Note>> GetAllNotes(string key)
        {
            throw new NotImplementedException();
        }

        public Task<Note> GetNoteById(string key, int id)
        {
            throw new NotImplementedException();
        }

        public Task<Note> UpdateNote(UpdateNoteDto updatedNote)
        {
            throw new NotImplementedException();
        }
    }
}
