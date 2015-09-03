using ElevenNote.Models.ViewModels;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            if (TempData["Result"] != null)
            {
                ViewBag.Success = TempData["Result"];
                TempData.Remove("Result");
            }
            var noteService = new NoteService();
            var notes = noteService.GetAllForUser(Guid.Parse(User.Identity.GetUserId())); 
            return View(notes);
        }


        [HttpGet]
        [ActionName("Create")]
        public ActionResult CreateGet()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(NoteEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var noteService = new NoteService();
                var userId = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Create(model, userId);
                TempData.Add("Result", result ? "Note added." : "Note not added.");
                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: Update

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult EditGet(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            return View(noteService.GetById(id, userId));
        }

        [ValidateInput(false)]
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(NoteEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var noteService = new NoteService();
                var userId = Guid.Parse(User.Identity.GetUserId());
                var result = noteService.Update(model, userId);
                TempData.Add("Result", result ? "Note updated." : "Note not updated.");
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            return View(noteService.GetById(id, userId));
        }

        // GET: Delete

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            return View(noteService.GetById(id, userId));
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var result = noteService.Delete(id, userId);
            TempData.Add("Result", result ? "Note deleted." : "Note not deleted.");
            return RedirectToAction("Index");
        }

        public ActionResult ToggleFavorite(int id)
        {
            var noteService = new NoteService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            noteService.ToggleFavorite(id, userId);
            return RedirectToAction("Index");
        }
    }
}