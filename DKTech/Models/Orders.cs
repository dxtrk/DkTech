using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DKTech.Models
{
    public class Orders
    {
        [Key]
public int order_id { get; set; }
        public int customer_id { get; set; }
        public int cart_id { get; set; } 
        public int payment_id { get; set; } 
        public DateTime order_date { get; set; }
        public DateTime pickup_date { get; set; }
        [ForeignKey("Cart")]
        public Cart Cart { get; set; }
        [ForeignKey("Customer")]
        public Customer Customer { get; set; }
    }

}
