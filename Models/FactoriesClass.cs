using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TuncDenizci.Models
{
    public class FactoriesClass
    {
        [Key]
        public int Id { get; set; }

        public string IndustryName { get; set; }
        public string LogUser { get; set; }
        public bool Deletes { get; set; }
        public List<IndustryClass> IndustryC { get; set; }
    }
}
