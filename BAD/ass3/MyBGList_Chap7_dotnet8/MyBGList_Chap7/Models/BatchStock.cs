using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models
{
    [Table("BatchStock")]
    public class BatchStock
    {
        [Key]
        public int BatchId { get; set; }
        public Batch Batch { get; set; }

        [Key]
        public int StockId { get; set; }
        public Stock Stock { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
