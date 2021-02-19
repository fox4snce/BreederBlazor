using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Models.Dtos.NoteDto
{
    public class CreateNoteDto
    {
        // Ref
        public int Id { get; set; }
        public int? BreedingRecordId { get; set; }
        public int? ContactId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        // Data
        public bool Medical { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }
}
