using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models
{
    [Table("Packet")]
    public class Packet
    {
        [Key]
        public int PacketId { get; set; }

        [Required]
        [MaxLength(9)]
        public string TrackId { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
