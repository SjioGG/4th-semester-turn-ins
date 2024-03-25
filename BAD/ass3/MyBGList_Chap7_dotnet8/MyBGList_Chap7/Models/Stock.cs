using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBGList.Models
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        [Required]
        [MaxLength(50)]
        public string SkName { get; set; }

        [Required]
        public int Quantity { get; set; }

        public List<BatchStock> BatchStocks { get; set; }
    }
}
