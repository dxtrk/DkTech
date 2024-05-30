using System.Security.Cryptography.Pkcs;

namespace DKTech.Models
{
    public class Cart
    {
        public int cart_id { get; set; }
        public int customer_id { get; set; } 
        public int product_id { get; set; }
        public int Quantity { get; set; }
        public int total_price { get; set; }




    }
}
