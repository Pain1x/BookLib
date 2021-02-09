using BookLib.DAL.Entities;
using BookLib.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BookLib.DAL.Repositories
{
    /// <summary>
    /// The class that works with database through the EntityFrameworkCore technology
    /// </summary>
    public class EFCoreRepository : IDataRepository
    {
        private readonly BookLibContext db;
        public EFCoreRepository(BookLibContext context)
        {
            db = context;
        }
        #region Public Methods
        /// <summary>
        /// Inserts an author and a book into database
        /// </summary>
        /// <param name="authorname">The Name of an author of a book</param>
        /// <param name="bookname">The boook's name</param>
        public void AddAnAuthorAndBook(string authorname, string bookname)
        {
            using (BookLibContext db = new BookLibContext())
            {
                var book = db.Books.FirstOrDefault(b => b.BookName == bookname);
                var author = db.Authors.FirstOrDefault(a => a.Name == authorname);
                if (book == null)
                {
                    if (author == null)
                    {
                        Author au = new Author { Name = authorname };
                        Book bo = new Book { BookName = bookname, Authors = au };
                        db.Authors.Add(au);
                        db.Books.Add(bo);
                        db.SaveChanges();
                    }
                    else
                    {
                        Book bo = new Book { BookName = bookname, Authors = author };
                        db.Books.Add(bo);
                        db.SaveChanges();
                    }
                }
                else
                {
                    throw new DuplicateNameException("There is such book in database");
                }
            }
        }
        /// <summary>
        /// Deletes a book from a database
        /// </summary>
        /// <param name="bookname">The name of a book to delete</param>
        public void DeleteABook(string bookname)
        {
            using (BookLibContext db = new BookLibContext())
            {
                var book = db.Books.FirstOrDefault(b => b.BookName == bookname);
                if (book == null)
                {
                    throw new Exception("There is no such book in database");
                }
                else
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Deletes an author from a database with all theirs book
        /// </summary>
        /// <param name="authorname">The name of an author to delete</param>
        public void DeleteAnAuthor(string authorname)
        {
            using (BookLibContext db = new BookLibContext())
            {
                var author = db.Authors.FirstOrDefault(a => a.Name == authorname);
                if (author == null)
                {
                    throw new Exception("There is no such author in database");
                }
                else
                {
                    db.Authors.Remove(author);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Updates the name of a book
        /// </summary>
        /// <param name="bookname">The name of book which you want to change></param>
        /// <param name="newbookname">The new name of a book</param>
        public void UpdateBookName(string bookname, string newbookname)
        {
            using (BookLibContext db = new BookLibContext())
            {
                var book = db.Books.FirstOrDefault(a => a.BookName == bookname);
                if (book == null)
                {
                    throw new Exception("There is no such book in database");
                }
                else
                {
                    book.BookName = newbookname;
                    db.Books.Update(book);
                    db.SaveChanges();
                }
            }
        }
        /// <summary>
        /// Updates the reading progress of a book
        /// </summary>
        /// <param name="finishpage">The page on which you have ended</param>
        /// <param name="bookname">The name of the book you are reading</param>
        public void UpdateProgress(string finishpage, string bookname)
        {
            using (BookLibContext db = new BookLibContext())
            {
                var progress = db.ReadingProgresses.FirstOrDefault(rp => rp.Books.BookName == bookname);
                if (progress == null)
                {
                    throw new Exception("There is no such book in database");
                }
                else
                {
                    int result;
                    if (int.TryParse(finishpage, out result) | finishpage == "Finished")
                    {
                        progress.FinishPage = finishpage;
                        db.ReadingProgresses.Update(progress);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Enter the number, please");
                    }
                }
            }
        }
        /// <summary>
        /// Returns the book from a database
        /// </summary>
        public IEnumerable<BookInfo> GetBooks()
        {
            //Fixes the bug without using
            using (BookLibContext db = new BookLibContext())
            {
                return (from b in db.Books
                        join a in db.Authors
                        on b.AuthorID equals a.ID
                        join rp in db.ReadingProgresses
                        on b.ID equals rp.BookdID
                        orderby a.Name
                        select new BookInfo
                        {
                            Name = b.Authors.Name,
                            BookName = b.BookName,
                            FinishPage = b.ReadingProgress.FinishPage,
                            IsCompleted = b.ReadingProgress.IsCompleted
                        }).ToList();
            }
        }
        #endregion
    }
}
