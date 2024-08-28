using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.WebAPI.Entities
{
    public class CheckoutDetail
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CheckoutDetailId { get; set; }

        [ForeignKey("CheckoutId")]
        public int CheckoutId { get; set; }
        public Checkout Checkout { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
