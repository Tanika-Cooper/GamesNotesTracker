using GamesNotesTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesNotesTracker.Controllers
{
    public class GamesController : Controller
    {
        ProjectContext _context;
        public GamesController(ProjectContext context) 
        {
            _context = context;
        }
        public IActionResult Index(int categoryId)
        {
            var category = _context.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefault();
            return View(category);
        }

        public async Task<IActionResult> ListDropdown()
        {
            //int userId = int.Parse(HttpContext.Session.GetString("UserId"));
            int userId = 1;

            var user = await _context.NoteLists.Where(c => c.UserId == userId).FirstOrDefaultAsync();


            var selectedList = user.NoteItems.Select(c => new SelectListItem
            {
                Value = c.NoteListId.ToString(),
                Text = c.NoteLists.ListName.ToString()
            }).ToList();

            ViewBag.Notes = selectedList;
            return PartialView("_PartialViewDropdown");
        }

        public async Task<IActionResult> NoteListPartial(int noteListId)
        {
            if (noteListId == 0)
            {
                return BadRequest("Please select a valid list.");
            }

            var notesList = await _context.NoteItems.Where(c => c.NoteListId == noteListId)
                                                    .Include(c => c.Note)
                                                    .Select(c => c.Note)
                                                    .ToListAsync();
            return PartialView("_PartialNoteList", notesList);
        }

        public async Task<String> DateCreated(int noteListId)
        {
            var date = await _context.NoteLists.Where(c => c.NoteListId == noteListId).FirstOrDefaultAsync();

            var returnDate = date.DateCreated.ToString("dd-MMM-yy");

            return returnDate;
        }
    }
}
