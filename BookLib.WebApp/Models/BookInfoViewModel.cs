using BookLib.BL.DTO;
using BookLib.WebApp.Pagination;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLib.WebApp.Models
{
    /// <summary>
    /// View model for BookInfo object
    /// </summary>
    public class BookInfoViewModel
    {
        [Required(ErrorMessage = "Please enter a valid author name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid book name")]
        public string BookName { get; set; }
        [Required]
        public string IsCompleted { get; set; }
        [Required(ErrorMessage = "Please enter a valid number")]
        public string FinishPage { get; set; }
        [Required]
        public IEnumerable<BookInfoDTO> Books { get; set; }
        [Required]
        public IEnumerable<AuthorDTO> Authors { get; set; }
        [Required]
        public PageInfo PageInfo { get; set; }
    }
}
