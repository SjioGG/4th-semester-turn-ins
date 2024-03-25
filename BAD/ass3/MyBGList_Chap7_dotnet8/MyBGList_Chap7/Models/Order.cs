using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [MaxLength(255)]
        public string DeliveryPlace { get; set; }

        [Required]
        public DateTime DeliveryDate { get; set; }

        public List<Packet> Packets { get; set; }
        public List<OrderBakingGood> OrderBakingGoods { get; set; }
    }
}
