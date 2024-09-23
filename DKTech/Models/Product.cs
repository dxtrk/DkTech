using DKTech.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKTech.Models
{
    public class Product
    {
        // Primary key for the Product table, uniquely identifies each product
        [Key]
        public int ProductID { get; set; }

        // Required field for the product name with a maximum length of 100 characters
        [Required]
        [StringLength(100)]
        // Custom label for displaying the product name in the UI
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } // Name of the product

        // Foreign key referencing the associated department
        [ForeignKey("Department")]
        // Custom label for displaying the department ID in the UI
        [Display(Name = "Department ID")]
        public int DepartmentID { get; set; }

        // Specifies that the column should store decimal values with two decimal places
        [Column(TypeName = "decimal(18,2)")]
        // Custom label for displaying the list price in the UI
        [Display(Name = "List Price")]
        public decimal ListPrice { get; set; } // Price of the product

        // Specifies that the quantity must be between 1 and 100
        [Range(1, 100)]
        public int Quantity { get; set; } // Available quantity of the product

        // Navigation property for the associated department
        public Department Department { get; set; } // Reference to the department this product belongs to

        // Navigation property for the collection of carts that include this product
        public ICollection<Cart> Carts { get; set; } // Related carts that contain this product
    }
}
