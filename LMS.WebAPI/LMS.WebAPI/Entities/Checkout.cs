using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.WebAPI.Entities
{
    public class Checkout
    {
        [Key]
        public int CheckoutId { get; set; }
        [Required]
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }
        [Required]
        public DateTime CheckoutDate { get; set; }

        [NotMapped]
        public DateTime DueDate => CheckoutDate.AddDays(5);

        public DateTime? ReturnDate { get; set; }

        public bool IsReturned => ReturnDate.HasValue;
    }
}
