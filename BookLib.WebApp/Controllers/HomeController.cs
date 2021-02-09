using BookLib.BL.DTO;
using BookLib.BL.Interfaces;
using BookLib.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using AutoMapper;
using BookLib.BL.Infrastructure;

namespace BookLib.WebApp.Controllers
{
    //TODO:Validations,theory,error handling,comments
    public class HomeController : Controller
    {
        ILibService libService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ILibService service)
        {
            libService = service;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<BookInfoDTO> retTab = libService.GetBooks();
            var mapper = new MapperConfiguration(config => config.CreateMap<BookInfoDTO, BookInfoViewModel>()).CreateMapper();
            var books = mapper.Map<IEnumerable<BookInfoDTO>, List<BookInfoViewModel>>(retTab);
            return View(books);
        }
        public IActionResult AddAnAuthorAndBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnAuthorAndBook(string authorname, string bookname)
        {
            try
            {
                libService.AddAnAuthorAndBook(authorname, bookname);
                return RedirectToAction("Index");
            }
           catch(ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return RedirectToAction("Error");
            }
        }
        public IActionResult DeleteAnAuthor()
        {
            return View();
        }
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
                ModelState.AddModelError(ex.Property, ex.Message);
                return RedirectToAction("Error");
            }
        }
        public IActionResult UpdateBookName()
        {
            return View();
        }
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
                ModelState.AddModelError(ex.Property, ex.Message);
                return RedirectToAction("Error");
            }
        }
        public IActionResult DeleteABook()
        {
            return View();
        }
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
                ModelState.AddModelError(ex.Property, ex.Message);
                return RedirectToAction("Error");
            }
        }
        public IActionResult UpdateProgress()
        {
            return View();
        }
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
                ModelState.AddModelError(ex.Property, ex.Message);
                return RedirectToAction("Error");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
