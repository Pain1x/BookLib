using BookLib.BL.DTO;
using System.Collections.Generic;

namespace BookLib.BL.Interfaces
{
   public interface ILibService
    {
        public void AddAnAuthorAndBook(string authorname, string bookname);
        public IEnumerable<BookInfoDTO> GetBooks();
        public void UpdateProgress(string finishpage, string bookname);
        public void UpdateBookName(string bookname, string newbookname);
        public void DeleteABook(string bookname);
        public void DeleteAnAuthor(string authorname);
    }
}
