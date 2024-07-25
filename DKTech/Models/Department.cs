using System.ComponentModel.DataAnnotations;

namespace DKTech.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }


        [Required]
        [StringLength(100)]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
    
