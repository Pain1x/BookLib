using BookLib.BL.DTO;
using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.WebApp.Models;
using BookLib.WebApp.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookLib.WebApp.Controllers
{
    public class BookController : Controller
    {
        //TODO:
        #region Private Members
        ILibService libService;
        #endregion
        #region Constructor
        public BookController(ILibService service)
        {
            libService = service;
        }
        #endregion
        #region GET Methods
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
        public IActionResult UpdateBookName()
        {
            IEnumerable<BookInfoDTO> bookinfoDTO = libService.GetBooks();
            PageInfo pageinfo = new PageInfo(bookinfoDTO.Count(), 0, 5);
            BookInfoViewModel bvm = new BookInfoViewModel { PageInfo = pageinfo, Books = bookinfoDTO };
            return View(bvm);
        }
        /// <summary>
        /// Returns the view
        /// </summary>
        /// <returns></returns>
        public IActionResult DeleteABook()
        {
            IEnumerable<BookInfoDTO> bookinfoDTO = libService.GetBooks();
            PageInfo pageinfo = new PageInfo(bookinfoDTO.Count(), 0, 5);
            BookInfoViewModel bvm = new BookInfoViewModel { PageInfo = pageinfo, Books = bookinfoDTO };
            return View(bvm);
        }
        /// <summary>
        /// Returns the view
        /// </summary>
        /// <returns></returns>
        public IActionResult UpdateProgress()
        {
            IEnumerable<BookInfoDTO> bookinfoDTO = libService.GetBooks();
            PageInfo pageinfo = new PageInfo(bookinfoDTO.Count(), 0, 5);
            BookInfoViewModel bvm = new BookInfoViewModel { PageInfo = pageinfo, Books = bookinfoDTO };
            return View(bvm);
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
                    return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Index","Home");
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
                return RedirectToAction("Index","Home");
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
