using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace DKTech.Models
{
    public class Customer
    {

        public int CustomerID { get; set; }
        //Displays "Last Name" instead of "Last_Name"
        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        DateTime MinDate = DateTime.Now;

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
}