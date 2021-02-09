using System;
using System.ComponentModel.DataAnnotations;

namespace BookLib.DAL.Entities
{
    /// <summary>
    /// Represents the Book table
    /// </summary>
    public partial class Book
    {
        private string bookname;
        [Required(ErrorMessage = "You didn't pass an id")]
        public int ID { get; set; }
        [Required(ErrorMessage = "You didn't pass an author id")]
        public int AuthorID { get; set; }
        [Required(ErrorMessage = "You didn't pass an book's name")]
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
        public virtual Author Authors { get; set; }
        public virtual ReadingProgress ReadingProgress { get; set; }
    }
}
