using System.ComponentModel.DataAnnotations;

namespace PresentlyServer.Dtos
{
    public class WishUrlCreate
    {
        [Required]
        public int WishId { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}
