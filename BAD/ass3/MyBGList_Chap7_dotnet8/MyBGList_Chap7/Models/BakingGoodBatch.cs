using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models
{
    [Table("BakingGoodBatch")]
    public class BakingGoodBatch
    {
        [Key]
        public int BatchId { get; set; }
        public Batch Batch { get; set; }

        [Key]
        public int BakingGoodId { get; set; }
        public BakingGood BakingGood { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
