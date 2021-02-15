using BookLib.BL.DTO;
using BookLib.WebApp.Pagination;
using System.Collections.Generic;

namespace BookLib.WebApp.Models
{
    /// <summary>
    /// View model for BookInfo object
    /// </summary>
    public class BookInfoViewModel
    {
        public string Name { get; set; }
        public string BookName { get; set; }
        public string IsCompleted { get; set; }
        public string FinishPage { get; set; }
        public IEnumerable<BookInfoDTO> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
