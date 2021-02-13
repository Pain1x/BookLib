using BookLib.BL.DTO;
using System.Collections.Generic;

namespace BookLib.BL.Interfaces
{
    /// <summary>
    /// It must be implemented to modify tables in database
    /// </summary>
    public interface ILibService
    {
        public int AddAnAuthorAndBook(string authorname, string bookname);
        public IEnumerable<BookInfoDTO> GetBooks();
        public int UpdateProgress(string finishpage, string bookname);
        public int UpdateBookName(string bookname, string newbookname);
        public int DeleteABook(string bookname);
        public int DeleteAnAuthor(string authorname);
    }
}
