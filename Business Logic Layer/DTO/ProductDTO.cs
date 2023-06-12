using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Secondzz.Data_Access_Layer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Second.Business_Logic_Layer.DTO
{
    public class ProductDTO
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }
        [Column(TypeName = "nvarchar(max)")]

        public string ProductImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string ProductDetails { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //s[MaxLength(50)]
        //public string Status { get; set; }=null;
    }
}
