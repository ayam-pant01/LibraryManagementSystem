namespace LMS.WebAPI.Models
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
