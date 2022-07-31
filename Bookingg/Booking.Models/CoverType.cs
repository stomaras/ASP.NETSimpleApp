using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int Price { get; set; }
    }
}
