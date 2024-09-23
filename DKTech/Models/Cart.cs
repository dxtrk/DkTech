using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKTech.Models
{
    public class Cart
    {
        // The "Key" attribute indicates that CartID is the primary key of this class
        [Key]
        public int CartID { get; set; }

        // The "Range" attribute restricts the Quantity to values between 0 and 100
        [Range(0, 100)]
        public int Quantity { get; set; }

        // The "Range" attribute restricts TotalPrice to values between 1 and 10,000
        [Range(1, 10000)]
        [Display(Name = "Total Price")] // Display name for the TotalPrice property
        public decimal TotalPrice { get; set; }

        // Foreign key property for associating a Cart with a Customer
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        // Navigation property to link the Cart to a Customer
        public Customer Customer { get; set; }

        // The "ForeignKey" attribute indicates that Products is a collection of Product entities associated with this Cart
        [ForeignKey("Product")]
        public ICollection<Product> Products { get; set; } // Collection of products in the cart
    }
}
