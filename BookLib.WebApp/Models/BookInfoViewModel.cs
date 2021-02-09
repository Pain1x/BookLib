using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLib.WebApp.Models
{
    public class BookInfoViewModel
    {
        public string Name { get; set; }
        public string BookName { get; set; }
        public string IsCompleted { get; set; }
        public string FinishPage { get; set; }
    }
}
