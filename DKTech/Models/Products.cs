using DKTech.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;

namespace DKTech.Models
{
    public class Products
    {
        [Key]

        public int Product_ID { get; set; }

        [Required]
        [StringLength(100)]
        public required string Product_Name { get; set; }

        [ForeignKey("Category")]

        public int Category_ID { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal ListPrice { get; set; }

        public int Quantity { get; set; }
        public required Category Category { get; set; }
    }
}






