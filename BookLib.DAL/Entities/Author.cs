using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLib.DAL.Entities
{
    /// <summary>
    /// Represents the Author table
    /// </summary>
    public partial class Author
    {
        private string authorname;
        public Author()
        {
            Books = new HashSet<Book>();
        }
        [Required(ErrorMessage = "You didn't pass an id")]
        public int ID { get; set; }
        [Required(ErrorMessage = "You didn't pass an author's name")]
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
        public virtual ICollection<Book> Books { get; set; }
    }
}
