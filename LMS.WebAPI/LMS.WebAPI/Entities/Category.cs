using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.WebAPI.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [StringLength(255)]
        public required string Name { get; set; }    

        public ICollection<Book> Books { get; set; }

    }
}
