using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKTech.Models
{
    public class Order
    {
        // Primary key for the Order table, uniquely identifies each order
        [Key]
        public int OrderID { get; set; }

        // Foreign key referencing the associated customer
        public int CustomerID { get; set; }

        // Specifies that this property should be formatted as a date
        [DataType(DataType.Date)]
        // Formats the date for display and input in "yyyy-MM-dd" format
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // Custom label for displaying the order date in the UI
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; } // Date when the order was placed

        // Specifies that this property should be formatted as a date
        [DataType(DataType.Date)]
        // Formats the date for display and input in "yyyy-MM-dd" format
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // Custom label for displaying the pickup date in the UI
        [Display(Name = "Pickup Date")]
        public DateTime PickupDate { get; set; } // Date when the order is scheduled for pickup

        // Navigation property for the associated customer
        public Customer Customer { get; set; } // Reference to the customer who placed the order
    }
}
