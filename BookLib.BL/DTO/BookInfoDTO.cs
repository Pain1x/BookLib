namespace BookLib.BL.DTO
{
    /// <summary>
    /// DTO object for BookInfo result of a query
    /// </summary>
    public class BookInfoDTO
    {
        public string Name { get; set; }
        public string BookName { get; set; }
        public string IsCompleted { get; set; }
        public string FinishPage { get; set; }
    }
}
