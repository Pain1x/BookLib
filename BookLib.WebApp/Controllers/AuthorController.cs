using BookLib.BL.DTO;
using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.WebApp.Models;
using BookLib.WebApp.Pagination;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace BookLib.WebApp.Controllers
{
    public class AuthorController : Controller
    {
        #region Private Members
        ILibService libService;
        private readonly IConfiguration configuration;
        string connectionString;
        #endregion
        #region Constructor
        public AuthorController(ILibService service, IConfiguration config)
        {
            libService = service;
            configuration = config;
            connectionString = configuration.GetConnectionString("Main");
        }
        #endregion
        #region GET Methods
        /// <summary>
        /// Returns the view
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteAnAuthor()
        {
            IEnumerable<AuthorDTO> authorinfoDTO = libService.GetAuthors(connectionString);
            PageInfo pageinfo = new PageInfo(authorinfoDTO.Count(), 0, 5);
            BookInfoViewModel bvm = new BookInfoViewModel { PageInfo = pageinfo, Authors = authorinfoDTO };
            return View(bvm);
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
                libService.DeleteAnAuthor(authorname, connectionString);
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
