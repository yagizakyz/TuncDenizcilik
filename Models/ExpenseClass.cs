using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuncDenizci.Models
{
    public class ExpenseClass
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int Day { get; set; }
        public int MonthID { get; set; }
        public int Year { get; set; }
        public string LogUser { get; set; }

        public virtual MonthClass Month { get; set; }
    }
}
