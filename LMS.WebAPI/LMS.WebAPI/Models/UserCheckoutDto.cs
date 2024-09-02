namespace LMS.WebAPI.Models
{
    public class UserCheckoutDto
    {
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public int NumberOfBooks { get; set; }
        public List<CheckoutDetailDto> CheckoutDetails { get; set; }
    }
}
