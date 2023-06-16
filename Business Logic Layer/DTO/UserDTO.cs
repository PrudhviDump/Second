using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Secondzz.Data_Access_Layer.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Secondzz.Business_Logic_Layer.DTO
{
    public class UserDTO
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Column(TypeName = "nvarchar(100)")]
        public string EmailId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

        [Required]
        [Phone]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }
        [Required]
        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public RoleDTO Role { get; set; }
    }
}
