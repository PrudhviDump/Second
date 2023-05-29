using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

    }
}
