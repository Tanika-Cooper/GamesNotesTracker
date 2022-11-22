using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GamesNotesTracker.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual List<CategoryItem> CategoryItems { get; set; }
    }
}
