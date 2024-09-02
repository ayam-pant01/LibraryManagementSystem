namespace LMS.WebAPI.Models
{
    public class ReviewForCreateAndUpdateDto
    {
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
