using DKTech.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;

namespace DKTech.Models
{
    public class Product
    {
        [Key]

        public int ProductID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        [ForeignKey("Category")]

        public int CategoryID { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public decimal ListPrice { get; set; }

        public int Quantity { get; set; }
        public Category Category { get; set; }
    }
}






