using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Secondzz.Business_Logic_Layer.DTO
{
    public class RoleDTO
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string RoleName { get; set; }
    }
}
