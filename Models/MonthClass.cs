using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuncDenizci.Models
{
    public class MonthClass
    {
        [Key]
        public int Id { get; set; }

        public string MonthName { get; set; }
        public decimal Amount { get; set; }

        public List<ExpenseClass> ExpenseC { get; set; }
    }
}
