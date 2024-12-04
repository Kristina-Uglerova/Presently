using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentlyServer.Models
{
    [Table("wish")]
    public class DbWish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("notes")]
        public string? Notes { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("bought")]
        public bool Bought { get; set; }
        
        [Column("currency")]
        public char Currency { get; set; }

        [ForeignKey("UserId")]
        public virtual DbUser? User { get; set; }
    }
}
