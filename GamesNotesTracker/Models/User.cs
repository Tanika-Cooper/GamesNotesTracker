using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesNotesTracker.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual List<Category> Categories { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
