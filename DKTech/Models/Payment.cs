using System.Security.Cryptography.Pkcs;

namespace DKTech.Models
{
    public class Payment
    {
        public int payment_id { get; set; }
        public int customer_id { get; set; }
        public int pay_amount { get; set; }
        public string pay_method { get; set; }
        public DateTime pay_date { get; set; }
    }
}
