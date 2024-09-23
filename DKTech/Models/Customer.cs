using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace DKTech.Models
{
    public class Customer
    {
        // Unique identifier for each customer
        public int CustomerID { get; set; }

        // Displays "Last Name" instead of "Last_Name" in UI for better readability
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        // Displays "First Name" in UI, allowing for clear labeling
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        // Specifies that this property should be formatted as a date
        [DataType(DataType.Date)] // Indicates that this field represents a date
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // Formats date for display and editing
        [Display(Name = "Order Date")] // Custom label for the UI
        public DateTime OrderDate { get; set; } // Holds the date of the customer's order

        // Specifies that this property is intended for storing an email address
        [DataType(DataType.EmailAddress)] // Indicates that the field is an email type
        [Required(ErrorMessage = "Please Enter Email ID")] // Makes this field mandatory
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")] // Validates that the email follows the correct format
        public string Email { get; set; } // Holds the customer's email address

        // Navigation property representing the collection of orders associated with this customer
        public ICollection<Order> Orders { get; set; } // Related orders, allowing for one-to-many relationship
    }
}
