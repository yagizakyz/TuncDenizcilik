using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuncDenizci.Models
{
    public class IstanbulClass
    {
        [Key]
        public int Id { get; set; }

        public int NO { get; set; }

        [Column(TypeName = "nvarchar(17)")]
        public string Plate { get; set; }
        public int Tonaj1 { get; set; }
        public int Tonaj2 { get; set; }
        public int Net { get; set; }

        public string Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string Time1 { get; set; }
        public string Time2 { get; set; }

        public string Material { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string Location { get; set; }
        public int Number { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string Destination { get; set; }

        public int IrsaliyeNo { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Chauffeur { get; set; }
        public string LogUser { get; set; }
        public bool Accepteds { get; set; }
    }
}
