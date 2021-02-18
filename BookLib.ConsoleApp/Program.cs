using BookLib.DAL.Entities;
using BookLib.DAL.Interfaces;
using BookLib.DAL.Repositories;
using System;
using System.Text;

namespace BookLib.ConsoleApp
{
    class Program
    {
        #region Properties
        //Holds the color of a font in console
        static ConsoleColor color = Console.ForegroundColor;
        static readonly BookLibContext db = new BookLibContext();
        #endregion
        static void Main(string[] args)
        {
            #region Main
            Console.ForegroundColor = ConsoleColor.Blue;
            //Correctly transforms symbols for input and output
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            TechnologySelector("");
            #endregion
        }
        #region Private Methods
        /// <summary>
        /// Adds a book to the db
        /// </summary>
        /// <param name="db">Class with needed methods</param>
        private static void AddABook(IDataRepository db, string connectionString)
        {
            try
            {
                string authorname, bookname;
                Console.WriteLine("Enter an book's name to add");
                bookname = Console.ReadLine();
                Console.WriteLine("Who has written that masterpiece?");
                authorname = Console.ReadLine();
                db.AddAnAuthorAndBook(authorname, bookname,connectionString);
                Console.WriteLine($"The book {bookname} by {authorname} was added to your collection");
            }
            catch (Exception ex)
            {
                RedConsole(ex);
            }
        }
        /// <summary>
        /// Gets books from a database and writes to console
        /// </summary>
        /// <param name="db">Class with needed methods</param>
        private static void GetBooks(IDataRepository db, string connectionString)
        {
            try
            {
                var result = db.GetBooks(connectionString);
                Console.WriteLine("{0,20} {1,25} {2,5} {3,5}", "AuthorName", "BookName", "FinishPage", "IsCompleted");
                foreach (var r in result)
                {
                    Console.WriteLine("{0,20} {1,25} {2,5} {3,5}", r.Name, r.BookName, r.FinishPage, r.IsCompleted);
                }
            }
            catch (Exception ex)
            {
                RedConsole(ex);
            }

        }
        /// <summary>
        /// Updates the reading progress
        /// </summary>
        /// <param name="db">Class with needed methods</param>
        private static void UpdateProgress(IDataRepository db, string connectionString)
        {
            try
            {
                string finishpage, bookname;
                Console.WriteLine("Enter the book's name to update your progress");
                bookname = Console.ReadLine();
                Console.WriteLine("Enter the page where you have finished reading");
                finishpage = Console.ReadLine();
                db.UpdateProgress(finishpage, bookname,connectionString);
                Console.WriteLine($"The book {bookname} was finished on page {finishpage}");
            }
            catch (Exception ex)
            {
                RedConsole(ex);
            }

        }
        /// <summary>
        ///  Updates the name of a book
        /// </summary>
        /// <param name="db">Class with needed methods</param>
        private static void UpdateBook(IDataRepository db, string connectionString)
        {
            try
            {
                string newbookname, bookname;
                Console.WriteLine("Enter the book's name to change");
                bookname = Console.ReadLine();
                Console.WriteLine("Enter it's new name");
                newbookname = Console.ReadLine();
                db.UpdateBookName(bookname, newbookname,connectionString);
                Console.WriteLine($"The book {bookname} was renamed to {newbookname}");
            }
            catch (Exception ex)
            {
                RedConsole(ex);
            }
        }
        /// <summary>
        /// Deletes a book from a database
        /// </summary>
        /// <param name="db">Class with needed methods</param>
        private static void DeleteABook(IDataRepository db, string connectionString)
        {
            try
            {
                string bookname;
                Console.WriteLine("Enter the book's name to delete");
                bookname = Console.ReadLine();
                db.DeleteABook(bookname,connectionString);
                Console.WriteLine($"The book {bookname} was deleted forever");
            }
            catch (Exception ex)
            {
                RedConsole(ex);
            }
        }
        /// <summary>
        /// Deletes an author
        /// </summary>
        /// <param name="db">Class with needed methods</param>
        private static void DeleteAnAuthor(IDataRepository db, string connectionString)
        {
            try
            {
                string authorname;
                Console.WriteLine("Enter the author's name to delete");
                authorname = Console.ReadLine();
                db.DeleteAnAuthor(authorname,connectionString);
                Console.WriteLine($"The author {authorname} was deleted with all of their's books");
            }
            catch (Exception ex)
            {
                RedConsole(ex);
            }
        }
        /// <summary>
        /// Changes the color of an exception to red
        /// </summary>
        /// <param name="ex">The given exception</param>
        private static void RedConsole(Exception ex)
        {
            color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = color;
        }
        /// <summary>
        /// Shows the options for the work with database
        /// </summary>
        /// <param name="db">Class with needed methods</param>
        private static void OptionSelector(IDataRepository db, string connectionString)
        {
            bool alive = true;
            while (alive)
            {
                Console.WriteLine("1.Get list of all books \t 2.Add a book to the library  \t 3.Change the name of a book");
                Console.WriteLine("4.Delete a book \t 5.Delete an author \t 6.Update the reading progress \t 7.Exit the program");
                Console.WriteLine("Enter the option number:");
                Console.ForegroundColor = color;
                try
                {
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            GetBooks(db,connectionString);
                            break;
                        case 2:
                            AddABook(db,connectionString);
                            break;
                        case 3:
                            UpdateBook(db,connectionString);
                            break;
                        case 4:
                            DeleteABook(db,connectionString);
                            break;
                        case 5:
                            DeleteAnAuthor(db,connectionString);
                            break;
                        case 6:
                            UpdateProgress(db,connectionString);
                            break;
                        case 7:
                            //exits to select technology menu
                            //alive = false;
                            //continue;
                            //Closes all app
                            Environment.Exit(0);
                            break;
                        default:
                            RedConsole(new Exception("Invalid option number"));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    RedConsole(ex);
                }
            }
        }
        /// <summary>
        /// Shows the technology with which you want to work
        /// </summary>
        private static void TechnologySelector(string connectionString)
        {
            bool alive = true;
            while (alive)
            {
                try
                {
                    Console.WriteLine("Choose your favorite technology");
                    Console.WriteLine("ADO.NET - 1");
                    Console.WriteLine("EF Core - 2");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            OptionSelector(new AdoRepository(), connectionString);
                            break;
                        case 2:
                            OptionSelector(new EFCoreRepository(db), connectionString);
                            break;
                        default:
                            RedConsole(new Exception("Invalid option number"));
                            break;
                    }
                }
                catch (Exception ex)
                {
                    RedConsole(ex);
                }
            }
        }
    }
    #endregion
}
