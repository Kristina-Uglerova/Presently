using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PresentlyServer.Dtos
{
    public class WishCreate
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public bool Bought { get; set; }
        [Required]
        public char Currency { get; set; }

        public WishCreate() { }
    }
}