using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Secondzz.Data_Access_Layer.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

       // [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string ProductName { get; set; }
        [Column(TypeName = "nvarchar(max)")]

        public string ProductImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string ProductDetails { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
       
        [MaxLength(50)]
        public bool Status { get; set; } 

    }
}
