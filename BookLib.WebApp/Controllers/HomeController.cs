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
        /// Returns an error
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
        #endregion
    }
}
