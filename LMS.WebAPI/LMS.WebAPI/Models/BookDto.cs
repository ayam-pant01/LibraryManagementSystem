namespace LMS.WebAPI.Models
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public string CategoryName { get; set; } 
        public bool IsAvailable { get; set; }
    }
}
