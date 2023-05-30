﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Secondzz.Data_Access_Layer.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

      //  [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string UserName { get; set; }

       // [Required]
        [EmailAddress]
        [Column(TypeName = "nvarchar(100)")]
        public string EmailId { get; set; }

      //  [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Password { get; set; }

      //  [Required]
        [Phone]
        [Column(TypeName = "nvarchar(20)")]
        public string PhoneNumber { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }


    }
}
