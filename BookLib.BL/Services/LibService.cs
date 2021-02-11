using AutoMapper;
using BookLib.BL.DTO;
using BookLib.BL.Infrastructure;
using BookLib.BL.Interfaces;
using BookLib.DAL.Entities;
using BookLib.DAL.Interfaces;
using System.Collections.Generic;

namespace BookLib.BL.Services
{
    /// <summary>
    /// Service that interacts with database using ADO.NET
    /// </summary>
    public class LibService : ILibService
    {
        /// <summary>
        /// A property that stores copy of UnitOfWork class
        /// </summary>
        IUnitOfWork Database { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unit">Class that implements UnitOfWork pattern</param>
        public LibService(IUnitOfWork unit)
        {
            Database = unit;
        }
        /// <summary>
        /// Inserts an author and a book into database
        /// </summary>
        /// <param name="authorname">The Name of an author of a book</param>
        /// <param name="bookname">The boook's name</param>
        public void AddAnAuthorAndBook(string authorname, string bookname)
        {
            try
            {
                Database.ADO.AddAnAuthorAndBook(authorname, bookname);
            }
            catch
            {
                throw new ValidationException("Author or book is already in library", "");
            }
        }
        /// <summary>
        /// Deletes a book from a database
        /// </summary>
        /// <param name="bookname">The name of the book to delete</param>
        public void DeleteABook(string bookname)
        {
            try
            {
                Database.ADO.DeleteABook(bookname);
            }
            catch
            {
                throw new ValidationException("There is no such book in library", "");
            }
        }
        /// <summary>
        /// Deletes an author from a database
        /// </summary>
        /// <param name="authorname">The name of an author to delete</param>
        public void DeleteAnAuthor(string authorname)
        {
            try
            {
                Database.ADO.DeleteAnAuthor(authorname);
            }
            catch
            {
                throw new ValidationException("There is no such author in library", "");
            }
        }
        /// <summary>
        /// Gets a list of books with authors
        /// </summary>
        /// <returns>The data from a database</returns>
        public IEnumerable<BookInfoDTO> GetBooks()
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<BookInfo, BookInfoDTO>());
                var mapper = new Mapper(config);
                return mapper.Map<IEnumerable<BookInfoDTO>>(Database.ADO.GetBooks());
            }
            catch
            {
                throw new ValidationException("Something went wrong", "");
            }
        }
        /// <summary>
        /// Changes the book name in case of a mistake
        /// </summary>
        /// <param name="bookname">The name of book which you want to change</param>
        /// <param name="newbookname">The new name of a book</param>
        public void UpdateBookName(string bookname, string newbookname)
        {
            try
            {
                Database.ADO.UpdateBookName(bookname, newbookname);
            }
            catch
            {
                throw new ValidationException("There is no such book in library", "");
            }
        }
        /// <summary>
        /// Updates the reading progress of a book
        /// </summary>
        /// <param name="finishpage">The page where you have finished reading</param>
        /// <param name="bookname">The name of the book which you are reading</param>
        public void UpdateProgress(string finishpage, string bookname)
        {
            try
            {
                Database.ADO.UpdateProgress(finishpage, bookname);
            }
            catch
            {
                throw new ValidationException("There is no such book in library", "");
            }
        }
    }
}
