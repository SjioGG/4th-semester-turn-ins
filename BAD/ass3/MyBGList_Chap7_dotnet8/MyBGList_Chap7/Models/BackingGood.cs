using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models
{
    [Table("BakingGood")]
    public class BakingGood
    {
        [Key]
        public int BakingGoodId { get; set; }

        [Required]
        [MaxLength(50)]
        public string BgName { get; set; }

        [Required]
        public DateTime DateProduced { get; set; }

        public List<OrderBakingGood> OrderBakingGoods { get; set; }
        public List<BakingGoodBatch> BakingGoodBatches { get; set; }
    }
}
