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
        public void AddAnAuthorAndBook(string authorname, string bookname);
        public IEnumerable<BookInfo> GetBooks();
        public void UpdateProgress(string finishpage, string bookname);
        public void UpdateBookName(string bookname, string newbookname);
        public void DeleteABook(string bookname);
        public void DeleteAnAuthor(string authorname);
    }
}
