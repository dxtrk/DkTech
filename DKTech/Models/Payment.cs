using System.Security.Cryptography.Pkcs;

namespace DKTech.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public int PayAmount { get; set; }
        public string PayMethod { get; set; }
        public DateTime PayDate { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }

    }
}
