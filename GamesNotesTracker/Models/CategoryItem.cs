using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesNotesTracker.Models
{
    public class CategoryItem
    {
        public int CategoryItemId { get; set; }
        public int CategoryId { get; set; }
        public int NoteListId { get; set; }
        public virtual List<NoteList> NoteLists { get; set; }
    }
}
