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
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department ID")]
        public int DepartmentID { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        [Display(Name = "List Price")]
        public decimal ListPrice { get; set; }
        [Range(1, 100)]
        public int Quantity { get; set; }
        public  Department Department { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}






