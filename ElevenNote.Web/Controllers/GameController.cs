using ElevenNote.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNote.Web.Controllers
{
    public class GameController : Controller
    {
        #region Get
        // GET: Game
        [HttpGet]
        [ActionName("Index")]
        public ActionResult IndexGet()
        {
            var correctAnswer = new Random().Next(1, 999);
            var guessCount = 0;
            Session["Answer"] = correctAnswer;
            Session["Guess Count"] = guessCount;
            return View();
        }
        
        #endregion

        #region POST

        // POST: Game
        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(GuessingGameViewModel model)
        {

            if (ModelState.IsValid)
            {
                Session["Guess Count"]=(int)Session["Guess Count"]+1;
                if (model.Guess == (int)Session["Answer"])
                {
                    ViewBag.Win = 0;
                }

                else
                {
                    var myVar = Math.Abs(model.Guess - (int)Session["Answer"]);
                    if (myVar <= 10)
                    {
                        ViewBag.Win = 1;
                    }

                    else if (myVar <= 50)
                    {
                        ViewBag.Win = 2;
                    }

                    else if (myVar <= 100)
                    {
                        ViewBag.Win = 3;
                    }

                    else if (myVar <= 400)
                    {
                        ViewBag.Win = 4;
                    }

                    else
                    {
                        ViewBag.Win = 5;
                    }

                }

            }
            return View(model);
        }

        #endregion

    }
}