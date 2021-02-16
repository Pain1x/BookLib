using BookLib.BL.DTO;
using System.Collections.Generic;

namespace BookLib.BL.Interfaces
{
    /// <summary>
    /// It must be implemented to modify tables in database
    /// </summary>
    public interface ILibService
    {
        public void AddAnAuthorAndBook(string authorname, string bookname);
        public IEnumerable<BookInfoDTO> GetBooks();
        public void UpdateProgress(string finishpage, string bookname);
        public void UpdateBookName(string bookname, string newbookname);
        public void DeleteABook(string bookname);
        public void DeleteAnAuthor(string authorname);
        public IEnumerable<AuthorDTO> GetAuthors();
    }
}
