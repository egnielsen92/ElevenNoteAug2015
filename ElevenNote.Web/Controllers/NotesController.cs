using ElevenNote.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            var notes = new List<NoteListViewModel>();
            notes.Add(new NoteListViewModel()
            {
                Id = 0,
                DateCreated = DateTime.UtcNow.AddMonths(-1),
                DateModified = DateTime.UtcNow,
                IsFavorite = true,
                Title = "This is the new note"
            });

            notes.Add(new NoteListViewModel()
            {
                Id = 1,
                DateCreated = DateTime.UtcNow.AddMonths(1),
                DateModified = DateTime.UtcNow,
                IsFavorite = true,
                Title = "This is the second note"
            });

            
            notes.Add(new NoteListViewModel()
            {
                Id = 2,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                IsFavorite = true,
                Title = "This is the third note"
            });

            return View(notes);
        }
    }
}