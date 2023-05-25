using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Secondzz.Data_Access_Layer.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string RoleName { get; set; }


    }
}
