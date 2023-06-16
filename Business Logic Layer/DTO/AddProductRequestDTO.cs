using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Secondzz.Data_Access_Layer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Second.Business_Logic_Layer.DTO
{
    public class AddProductRequestDTO
    {
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }
        [Column(TypeName = "nvarchar(max)")]

        public string ProductImageUrl { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string ProductDetails { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        

    }
}
