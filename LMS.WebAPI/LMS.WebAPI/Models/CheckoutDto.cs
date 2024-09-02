    namespace LMS.WebAPI.Models
{
    public class CheckoutDto
    {
        public int CheckoutId { get; set; }
        public string UserName { get; set; } 
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public int NumberOfBooks { get; set; }

    }
}
