using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmporiumRemuneration.Models
{
    [Table(name : "EmporiumTranscations")]
    public class TranscationInformation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid TranscationID { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Consumers")]
        public long CustomerID { get; set; }

        [Column(TypeName= "DATETIME")]
        public DateTime TransDate { get; set; }

        [Column(TypeName = "VARCHAR(MAX)")]
        public string  PurchaseList { get; set; }
    }

    public class TranscationDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid TranscationID { get; set; }

        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Consumers")]
        public long CustomerID { get; set; }
        public DateTime TransDate { get; set; }
        public List<ProductInfo> PurchaseList { get; set; }

        public decimal TransTotal { get; set;}
        public int RewardPoints { get; set; }

    }
}
