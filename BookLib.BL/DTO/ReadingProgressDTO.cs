namespace BookLib.BL.DTO
{
    /// <summary>
    /// DTO object for ReadingProgress table
    /// </summary>
    public class ReadingProgressDTO
    {
        public int ID { get; set; }
        public string IsCompleted { get; set; }
        public string FinishPage { get; set; }
    }
}
