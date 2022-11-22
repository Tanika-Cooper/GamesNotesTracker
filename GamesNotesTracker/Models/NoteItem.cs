using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamesNotesTracker.Models
{
    public class NoteItem
    {
        public int NoteItemId { get; set; }
        public int NoteId { get; set; }
        public int NoteListId { get; set; }

        [ForeignKey("NoteId")]
        public virtual NoteContent Note { get; set; }
        [ForeignKey("NoteListId")]
        public virtual NoteList NoteLists { get; set; }
    }
}
