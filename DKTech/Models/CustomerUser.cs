using System.ComponentModel.DataAnnotations;

namespace DKTech.Models
{
    public class CustomerUser
    {

        public int CustomerID { get; set; }
        public string Last_Name { get; set; }
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Order_date { get; set; }

        public ICollection<Orders> Orders { get; set; }

    }
}