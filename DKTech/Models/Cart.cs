using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;

namespace DKTech.Models
{
    public class Cart

    {
        [Key]
        public int CartID { get; set; }

        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }


        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Product")]
     
        public Product Product { get; set; }
    }
}
