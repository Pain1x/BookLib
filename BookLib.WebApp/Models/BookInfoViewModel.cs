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
    }
}
