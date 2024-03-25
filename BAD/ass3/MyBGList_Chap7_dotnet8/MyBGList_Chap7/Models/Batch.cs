using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models
{
    [Table("Batch")]
    public class Batch
    {
        [Key]
        public int BatchId { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [Required]
        public DateTime ActualEndTime { get; set; }

        public List<BakingGoodBatch> BakingGoodBatches { get; set; }
        public List<BatchStock> BatchStocks { get; set; }
    }

}
