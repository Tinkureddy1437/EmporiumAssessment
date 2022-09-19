using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmporiumRemuneration.Models
{
    [Table(name:"Consumers")]
    public class ConsumerInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Key]
        [Column(TypeName ="INT")]
        public long ConsumerID { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Address1 { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        public string Address2 { get; set; }

        [Column(TypeName = "VARCHAR(10)")]
        public string ZipCode { get; set; }

        [Column(TypeName = "VARCHAR(20)")]
        public string PhoneNumber { get; set; }

    }
}
