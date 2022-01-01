using BreederBlazor.Models.Base;
using BreederBlazor.Models.Dtos.NoteDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Services.Notes
{
    public interface INoteService
    {
        // Create
        Task<List<Note>> CreateNote(CreateNoteDto newNote, string key);

        // Read
        Task<List<Note>> GetAllNotes(string key);

        Task<Note> GetNoteById(string key, int id);

        // Update
        Task<Note> UpdateNote(UpdateNoteDto updatedNote, string key);

        // Delete
        Task<List<Note>> DeleteNote(int id, string key);
    }
}
