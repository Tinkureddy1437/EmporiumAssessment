using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmporiumRemuneration.Models
{
    [Table(name: "Products")]
    public class ProductInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName = "INT")]
        public int ProdId {get;set;}

        [Column(TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "INT")]
        public int Quantity { get; set; }
    }
}
