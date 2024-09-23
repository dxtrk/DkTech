using System.ComponentModel.DataAnnotations;

namespace DKTech.Models
{
    public class Department
    {
        // Unique identifier for each department
        public int DepartmentID { get; set; }

        // Required attribute ensures this field must be filled
        [Required]
        // Limits the length of the department name to 100 characters
        [StringLength(100)]
        // Custom label for displaying the department name in the UI
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; } // Holds the name of the department

        // Navigation property for the collection of products associated with this department
        public ICollection<Product> Products { get; set; } // Related products, allowing for one-to-many relationship
    }
}
