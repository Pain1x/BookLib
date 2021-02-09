using System;

namespace BookLib.DAL.Entities
{
    /// <summary>
    /// Class the represents a table which is returned by method that returns info about books
    /// </summary>
    public class BookInfo
    {
        /// <summary>
        ///The same named input parameters for methods in repository
        /// </summary>
        private string finishpage;
        private string authorname;
        private string iscompleted;
        private string bookname;
        /// <summary>
        /// Propetie that corresponds the author's name field in table in database
        /// </summary>
        public string Name
        {
            get
            {
                return authorname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception($"{nameof(authorname)} can't be null!");
                }
                else
                {
                    authorname = value;
                }
            }
        }
        /// <summary>
        /// Propetie that corresponds the book's name field in table in database
        /// </summary>
        public string BookName
        {
            get
            {
                return bookname;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception($"{nameof(bookname)} can't be null!");
                }
                else
                {
                    bookname = value;
                }
            }
        }
        /// <summary>
        /// Propetie that corresponds the FinishPage field in table in database
        /// </summary>
        public string FinishPage
        {
            get
            {
                return finishpage;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception($"{nameof(finishpage)} can't be null!");
                }
                else
                {
                    finishpage = value;
                }
            }
        }
        /// <summary>
        /// Propetie that corresponds the IsCompleted field in table in database
        /// </summary>
        public string IsCompleted
        {
            get
            {
                return iscompleted;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception($"{nameof(iscompleted)} can't be null!");
                }
                else
                {
                    iscompleted = value;
                }
            }
        }
    }
}
