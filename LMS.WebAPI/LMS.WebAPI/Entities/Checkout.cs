using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.WebAPI.Entities
{
    public class Checkout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckoutId { get; set; }
        [ForeignKey("UserId")]
        public required string UserId { get; set; }
        public AppUser User { get; set; }
        [Required]
        public DateTime CheckoutDate { get; set; }

        [NotMapped]
        public DateTime DueDate => CheckoutDate.AddDays(5);
        public ICollection<CheckoutDetail> CheckoutDetails { get; set; } = new List<CheckoutDetail>();
    }
}
