using System;
using System.Collections.Generic;
using System.Text;

namespace BookLib.BL.DTO
{
   public class ReadingProgressDTO
    {
        public int ID { get; set; }
        public string IsCompleted { get; set; }
        public string FinishPage { get; set; }
    }
}
