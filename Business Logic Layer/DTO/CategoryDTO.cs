using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Second.Business_Logic_Layer.DTO
{
    public class CategoryDTO
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string CategoryName { get; set; }
    }
}
