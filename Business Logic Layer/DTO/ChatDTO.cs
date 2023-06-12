using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Secondzz.Data_Access_Layer.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Second.Business_Logic_Layer.DTO
{
    public class ChatDTO
    {
        [Key]
        public int MessageId { get; set; }
        [ForeignKey("User")]
        public int SenderId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }
        [ForeignKey("User")]
        public int RecieverId { get; set; }
        public User Sender { get; set; }
        public User Reciever { get; set; }
        public Product Product { get; set; }

    }
}
