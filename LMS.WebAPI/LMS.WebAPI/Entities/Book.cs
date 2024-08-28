using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.WebAPI.Entities
{
    [Index(nameof(Book.ISBN), IsUnique = true)]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        [StringLength(255)]
        public required string Title { get; set; }
        [StringLength(255)]
        public required string Author { get; set; }
        [StringLength(1000)]
        public required string Description { get; set; }
        [Url]
        public required string CoverImage { get; set; }

        [StringLength(255)]
        public required string Publisher { get; set; }

        public required DateTime PublicationDate { get; set; }

        [StringLength(20)]
        public required string ISBN { get; set; }
        
        public required int PageCount { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsAvailable { get; set; } = true;
        public ICollection<Checkout> Checkouts { get; set; }
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        //public ICollection<Review> Reviews { get; set; }
    }
}
