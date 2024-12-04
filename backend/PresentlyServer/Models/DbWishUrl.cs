using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresentlyServer.Models
{
    [Table("wish_url")]
    public class DbWishUrl
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("wish_id")]
        public int WishId { get; set; }
        [Column("url")]
        public string Url { get; set; }
        [Column("price")]
        public int Price { get; set; }

        [ForeignKey("WishId")]
        public virtual DbWish? Wish { get; set; }
    }
}
