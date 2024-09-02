namespace LMS.WebAPI.Models
{
    public class BookForCreateAndUpdateDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public int CategoryId { get; set; } // Foreign key to associate with the Category
    }

}
