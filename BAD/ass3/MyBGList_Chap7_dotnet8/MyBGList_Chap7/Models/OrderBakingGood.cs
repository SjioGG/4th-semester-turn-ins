using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models
{
    [Table("OrderBakingGood")]
    public class OrderBakingGood
    {
        [Key]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Key]
        public int BakingGoodId { get; set; }
        public BakingGood BakingGood { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
