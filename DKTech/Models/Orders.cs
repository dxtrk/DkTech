namespace DKTech.Models
{
    public class Orders
    {
public int order_id { get; set; }
        public int customer_id { get; set; }
        public int cart_id { get; set; } 
        public int payment_id { get; set; } 
        public DateTime order_date { get; set; }
        public DateTime pickup_date { get; set; }
    }

}
