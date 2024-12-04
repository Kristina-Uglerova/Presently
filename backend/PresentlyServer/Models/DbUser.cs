using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresentlyServer.Models
{
    [Table("user")]
    public class DbUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        public string Username { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("birthday")]
        public DateTime Birthday { get; set; }
        [Column("salt")]
        public byte[] Salt { get; set; }
        [Column("hash")]
        public byte[] Hash { get; set; }
    }
}
