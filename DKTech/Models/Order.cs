using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKTech.Models
{
    public class Order
    {
        //The Primary key attribute, shows SQL server that OrderID is the primary class of this field.
        [Key]
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        
        public DateTime OrderDate { get; set; }
        public DateTime PickupDate { get; set; }
        
  

        public Customer Customer { get; set; }
    }

}
