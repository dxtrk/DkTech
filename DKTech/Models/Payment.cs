using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs;

namespace DKTech.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        
        [Range(1, 100000)]
        [Display(Name = "Pay Amount")]
        public int PayAmount { get; set; }
        [Display(Name = "Pay Method")]
        public string PayMethod { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Time")]
        public DateTime PayDate { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }

    }
}
