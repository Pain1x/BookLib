using BookLib.DAL.Entities;
using BookLib.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BookLib.DAL.Repositories
{
    /// <summary>
    /// The class that works with database through the ADO.NET technology
    /// </summary>
    public class AdoRepository : IDataRepository
    {
        #region Private Members
        //Gets the connection string
        string connectionString;
        #endregion
        public AdoRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Main"].ConnectionString;
        }
        #region Public Methods
        /// <summary>
        /// Inserts an author and a book into database
        /// </summary>
        /// <param name="authorname">The Name of an author of a book</param>
        /// <param name="bookname">The boook's name</param>
        public void AddAnAuthorAndBook(string authorname, string bookname)
        {
            if (IsBookInDb(bookname) | string.IsNullOrEmpty(bookname))
            {
                throw new DuplicateNameException("There is such book in database");
            }
            else
            {
                //Creates an author if they are not in a db with a book
                //if they are exist in db then just adds a book 
                //After that adds record to the Progress table with help of a trigger
                string sqlProcedure = "sp_CreateBook";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlProcedure, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter authorParam = new SqlParameter
                    {
                        ParameterName = "@AuthorName",
                        Value = authorname
                    };
                    SqlParameter bookParam = new SqlParameter
                    {
                        ParameterName = "@BookName",
                        Value = bookname
                    };
                    cmd.Parameters.Add(authorParam);
                    cmd.Parameters.Add(bookParam);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Gets a list of books with authors
        /// </summary>
        /// <returns>The data from a database</returns>
        public IEnumerable<BookInfo> GetBooks()
        {
            //Selects every book from a table with it's author, completion and finishpage
            string sqlProcedure = "sp_SelectBooks";
            List<BookInfo> table = new List<BookInfo>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        BookInfo rt = new BookInfo
                        {
                            Name = reader.GetString(0),
                            BookName = reader.GetString(1),
                            FinishPage = reader.GetString(2),
                            IsCompleted = reader.GetString(3)
                        };
                        table.Add(rt);
                    }
                }
                reader.Close();
            }
            return table;
        }
        /// <summary>
        /// Updates the reading progress of a book
        /// </summary>
        /// <param name="finishpage">The page where you have finished reading</param>
        /// <param name="bookname">The name of the book which you are reading</param>
        public void UpdateProgress(string finishpage, string bookname)
        {
            if (IsBookInDb(bookname) | string.IsNullOrEmpty(bookname))
            {
                //Updates the reading progress and if you haven't finished the book
                //changes the field IsCompleted to 'No' otherwise 'Yes'
                string sqlProcedure = "sp_UpdateProgress";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    int result;
                    if (int.TryParse(finishpage, out result) | finishpage == "Finished")
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(sqlProcedure, con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter finishParam = new SqlParameter
                        {
                            ParameterName = "@FinishPage",
                            Value = finishpage
                        };
                        SqlParameter bookParam = new SqlParameter
                        {
                            ParameterName = "@BookName",
                            Value = bookname
                        };
                        cmd.Parameters.Add(finishParam);
                        cmd.Parameters.Add(bookParam);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("Enter the nubmer, please");
                    }
                }
            }
            else
            {
                throw new Exception("There is no such a book in a database");
            }
        }
        /// <summary>
        /// Changes the book name in case of a mistake
        /// </summary>
        /// <param name="bookname">The name of book which you want to change</param>
        /// <param name="newbookname">The new name of a book</param>
        public void UpdateBookName(string bookname, string newbookname)
        {
            if (IsBookInDb(bookname) | string.IsNullOrEmpty(bookname))
            {
                //Updates the name of a book using two parameters 
                //- name of a book and new name of that book
                string sqlProcedure = "sp_UpdateBooks";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlProcedure, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter newBookParam = new SqlParameter
                    {
                        ParameterName = "@BookNameNew",
                        Value = newbookname
                    };
                    SqlParameter bookParam = new SqlParameter
                    {
                        ParameterName = "@BookName",
                        Value = bookname
                    };
                    cmd.Parameters.Add(newBookParam);
                    cmd.Parameters.Add(bookParam);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("There is no such a book in a database");
            }
        }
        /// <summary>
        /// Deletes a book from a database
        /// </summary>
        /// <param name="bookname">The name of the book to delete</param>
        public void DeleteABook(string bookname)
        {
            if (IsBookInDb(bookname) & !string.IsNullOrEmpty(bookname))
            {
                //Deletes a book from a database
                string sqlProcedure = "sp_DeleteBook";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlProcedure, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter bookParam = new SqlParameter
                    {
                        ParameterName = "@BookName",
                        Value = bookname
                    };
                    cmd.Parameters.Add(bookParam);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("There is no such a book in a database");
            }

        }
        /// <summary>
        /// Deletes an author from a database
        /// </summary>
        /// <param name="authorname">The name of an author to delete</param>
        public void DeleteAnAuthor(string authorname)
        {
            if (IsAuthorInDb(authorname) & !string.IsNullOrEmpty(authorname))
            {
                string sqlProcedure = "sp_DeleteAuthor";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sqlProcedure, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter authorParam = new SqlParameter
                    {
                        ParameterName = "@AuthorName",
                        Value = authorname
                    };
                    cmd.Parameters.Add(authorParam);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                throw new Exception("There is no such an author in a database");
            }

        }
        /// <summary>
        /// Checks if the book is in database
        /// </summary>
        /// <param name="bookname">The name of a book to check</param>
        /// <returns>True of false statement</returns>
        private bool IsBookInDb(string bookname)
        {
            //Selects a book from a db
            string sqlProcedure = "sp_BookCheck";
            object result;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter bookParam = new SqlParameter
                {
                    ParameterName = "@BookName",
                    Value = bookname
                };
                cmd.Parameters.Add(bookParam);
                result = cmd.ExecuteScalar();
            }
            return result != null;
        }
        /// <summary>
        /// Checks if the author is in database
        /// </summary>
        /// <param name="authorname">The name of an author to check</param>
        /// <returns>True of false statement</returns>
        private bool IsAuthorInDb(string authorname)
        {
            //Selects an author from a db
            string sqlProcedure = "sp_CheckAuthor";
            object result;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlProcedure, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter authorParam = new SqlParameter
                {
                    ParameterName = "@AuthorName",
                    Value = authorname
                };
                cmd.Parameters.Add(authorParam);
                result = cmd.ExecuteScalar();
            }
            return result != null;
        }
        #endregion
    }
}
