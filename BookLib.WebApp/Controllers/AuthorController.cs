using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookLib.WebApp.Controllers
{
    public class AuthorController : Controller
    {
        #region Private Members
        ILibService libService;
        #endregion
        #region Constructor
        public AuthorController(ILibService service)
        {
            libService = service;
        }
        #endregion
        #region GET Methods
        /// <summary>
        /// Returns the view
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteAnAuthor()
        {
            return View();
        }
        #endregion
        #region POST Methods
        /// <summary>
        /// POST version of a method to delete an author
        /// </summary>
        /// <param name="authorname">Name of an author to remove from library</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteAnAuthor(string authorname)
        {
            try
            {
                libService.DeleteAnAuthor(authorname);
                return RedirectToAction("Index","Home");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message.ToString());
            }
        }
        #endregion
    }
}
