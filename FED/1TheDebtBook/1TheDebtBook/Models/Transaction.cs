using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1TheDebtBook.Models
{
    public class Transaction
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
        public int DebtorId { get; set; }
    }
}
