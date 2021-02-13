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
        public int AddAnAuthorAndBook(string authorname, string bookname);
        public IEnumerable<BookInfo> GetBooks();
        public int UpdateProgress(string finishpage, string bookname);
        public int UpdateBookName(string bookname, string newbookname);
        public int DeleteABook(string bookname);
        public int DeleteAnAuthor(string authorname);
    }
}
