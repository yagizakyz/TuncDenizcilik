using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuncDenizci.Models
{
    public class PersonClass
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Surname { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Nickname { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string Roles { get; set; }
        public string LogUser { get; set; }
        public bool Deletes { get; set; }
    }
}
