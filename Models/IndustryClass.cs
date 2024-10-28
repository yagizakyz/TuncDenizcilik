using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuncDenizci.Models
{
    public class IndustryClass
    {
        [Key]
        public int Id { get; set; }

        public int IrsaliyeNo { get; set; }

        [Column(TypeName = "nvarchar(17)")]
        public string Plate { get; set; }

        public int Tonaj { get; set; }

        public string ShipName { get; set; }

        public int FactoriesID { get; set; }

        public string DateT { get; set; }

        public string LogUser { get; set; }

        public virtual FactoriesClass Factories { get; set; }
    }
}
