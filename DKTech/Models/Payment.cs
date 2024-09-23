using System.ComponentModel.DataAnnotations;

namespace DKTech.Models
{
    public class Payment
    {
        // Primary key for the Payment table, uniquely identifies each payment
        public int PaymentID { get; set; }

        // Foreign key referencing the associated customer
        public int CustomerID { get; set; }

        // Specifies that the payment amount must be between 1 and 100,000
        [Range(1, 100000)]
        // Custom label for displaying the payment amount in the UI
        [Display(Name = "Pay Amount")]
        public int PayAmount { get; set; } // Amount paid by the customer

        // Method of payment (e.g., credit card, cash, etc.)
        [Display(Name = "Pay Method")]
        public string PayMethod { get; set; } // Type of payment method used

        // Specifies that this property should be formatted as a date
        [DataType(DataType.Date)]
        // Formats the date for display and input in "yyyy-MM-dd" format
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        // Custom label for displaying the payment date in the UI
        [Display(Name = "Date Time")]
        public DateTime PayDate { get; set; } // Date when the payment was made

        // Foreign key referencing the associated order
        public int OrderID { get; set; }

        // Navigation property for the associated order
        public Order Order { get; set; } // Reference to the order related to this payment
    }
}
