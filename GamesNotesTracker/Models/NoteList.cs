using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamesNotesTracker.Models
{
    public class NoteList
    {
        public int NoteListId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public string ListName { get; set; }
        public virtual List<NoteItem> NoteItems { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
