using BookLib.DAL.Entities;
using System.Collections.Generic;

namespace BookLib.DAL.Interfaces
{
    /// <summary>
    /// Interface for realization of Repository pattern
    /// </summary>
    public interface IDataRepository
    {
        //Methods that has to be implemented
        public void AddAnAuthorAndBook(string authorname, string bookname, string connectionString);
        public IEnumerable<BookInfo> GetBooks(string connectionString);
        public void UpdateProgress(string finishpage, string bookname, string connectionString);
        public void UpdateBookName(string bookname, string newbookname, string connectionString);
        public void DeleteABook(string bookname, string connectionString);
        public void DeleteAnAuthor(string authorname, string connectionString);
        public IEnumerable<Author> GetAuthors(string connectionString);
    }
}
