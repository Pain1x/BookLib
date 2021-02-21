using BookLib.BL.DTO;
using BookLib.BL.Interfaces;
using BookLib.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookLib.BL.Infrastructure;
using BookLib.WebApp.Pagination;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace BookLib.WebApp.Controllers
{
    //TODO:
    /// <summary>
    /// Main controller of an app
    /// </summary>
    public class HomeController : Controller
    {
        #region Private Members
        ILibService libService;
        private readonly IConfiguration configuration;
        string connectionString;
        #endregion
        #region Constructor
        public HomeController(ILibService service, IConfiguration config)
        {
            libService = service;
            configuration = config;
            connectionString= configuration.GetConnectionString("Main");
        }
        #endregion
        #region GET Methods
        /// <summary>
        /// Returns the view with list of books
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int page = 1)
        {
            try
            {
                int pagesize = 10;
                IEnumerable<BookInfoDTO> bookinfoDTO = libService.GetBooks(connectionString);
                int totalpages = bookinfoDTO.Count();
                PageInfo pageinfo = new PageInfo(totalpages, page, pagesize);
                BookInfoViewModel bvm = new BookInfoViewModel { PageInfo = pageinfo, Books = bookinfoDTO.Skip((page - 1) * pagesize).Take(pagesize) };
                return View(bvm);
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
