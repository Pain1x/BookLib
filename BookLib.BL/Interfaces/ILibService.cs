using BookLib.BL.DTO;
using System.Collections.Generic;

namespace BookLib.BL.Interfaces
{
    /// <summary>
    /// It must be implemented to modify tables in database
    /// </summary>
    public interface ILibService
    {
        public void AddAnAuthorAndBook(string authorname, string bookname, string connectionString);
        public IEnumerable<BookInfoDTO> GetBooks(string connectionString);
        public void UpdateProgress(string finishpage, string bookname, string connectionString);
        public void UpdateBookName(string bookname, string newbookname, string connectionString);
        public void DeleteABook(string bookname, string connectionString);
        public void DeleteAnAuthor(string authorname, string connectionString);
        public IEnumerable<AuthorDTO> GetAuthors(string connectionString);
    }
}
