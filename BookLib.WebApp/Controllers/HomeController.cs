using BookLib.BL.DTO;
using BookLib.BL.Interfaces;
using BookLib.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using BookLib.BL.Infrastructure;

namespace BookLib.WebApp.Controllers
{
    //TODO:Pagination?
    /// <summary>
    /// Main controller of an app
    /// </summary>
    public class HomeController : Controller
    {
        #region Private Members
        ILibService libService;
        #endregion
        #region Constructor
        public HomeController(ILibService service)
        {
            libService = service;
        }
        #endregion
        #region GET Methods
        /// <summary>
        /// Returns the view with list of books
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            try
            {
                IEnumerable<BookInfoDTO> bookinfo = libService.GetBooks();
                var mapper = new MapperConfiguration(config => config.CreateMap<BookInfoDTO, BookInfoViewModel>()).CreateMapper();
                var books = mapper.Map<IEnumerable<BookInfoDTO>, List<BookInfoViewModel>>(bookinfo);
                return View(books);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message.ToString());
            }
        }
        /// <summary>
        /// Returns the view
        /// </summary>
        /// <returns></returns>
        public IActionResult AddAnAuthorAndBook()
        {
            return View();
        }
        /// <summary>
        /// Returns the view
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteAnAuthor()
        {
            return View();
        }
        /// <summary>
        /// Returns the view
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateBookName()
        {
            return View();
        }
        /// <summary>
        /// Returns the view
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteABook()
        {
            return View();
        }
        /// <summary>
        /// Returns the view
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateProgress()
        {
            return View();
        }
        /// <summary>
        /// Returns an error
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        #endregion
        #region POST Methods
        /// <summary>
        /// POST version of method to add a book to library
        /// </summary>
        /// <param name="authorname">Name of an author to add to library</param>
        /// <param name="bookname">Name of a book to add to library</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddAnAuthorAndBook(string authorname, string bookname)
        {
            try
            {
                libService.AddAnAuthorAndBook(authorname, bookname);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message.ToString());
            }
        }
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
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message.ToString());
            }
        }
        /// <summary>
        /// POST version of a method to rename a book
        /// </summary>
        /// <param name="bookname">Name of a book to rename</param>
        /// <param name="newbookname">New name of a book</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateBookName(string bookname, string newbookname)
        {
            try
            {
                libService.UpdateBookName(bookname, newbookname);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message.ToString());
            }
        }
        /// <summary>
        /// POST version of a method to delete a book
        /// </summary>
        /// <param name="bookname">Name of a book to remove form a library</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteABook(string bookname)
        {
            try
            {
                libService.DeleteABook(bookname);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message.ToString());
            }
        }
        /// <summary>
        /// POST version of a method to update reading progress
        /// </summary>
        /// <param name="finishpage">Page where you have finished reading</param>
        /// <param name="bookname">Name of a book which you are reading</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult UpdateProgress(string finishpage, string bookname)
        {
            try
            {
                libService.UpdateProgress(finishpage, bookname);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message.ToString());
            }
        }
        #endregion
    }
}
