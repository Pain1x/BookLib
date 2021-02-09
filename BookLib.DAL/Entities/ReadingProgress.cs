using System;
using System.ComponentModel.DataAnnotations;

namespace BookLib.DAL.Entities
{
    /// <summary>
    /// Represent the ReadingProgress table
    /// </summary>
    public partial class ReadingProgress
    {
        private string finishpage;
        private string iscompleted;
        [Required(ErrorMessage = "You didn't pass an Id")]
        public int ID { get; set; }
        [Required(ErrorMessage = "You didn't pass an book's id")]
        public int BookdID { get; set; }
        [Required(ErrorMessage = "You didn't pass an IsCompleted field")]
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
        [Required(ErrorMessage = "You didn't pass finish page")]
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
        public virtual Book Books { get; set; }
    }
}
