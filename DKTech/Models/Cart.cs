using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;

namespace DKTech.Models
{
    public class Cart
       
    {
        //The "Key" attribute tells SQL server, for e.g. "CartID" field is the primary of this class
        [Key]
        public int CartID { get; set; }
        //"The "Range" attribute, ranges the numbers from 1 - 9 to prevent negative numbers.
        [Range(1,9)] 
        public int Quantity { get; set; }
        [Range(1, 9)]
        public decimal TotalPrice { get; set; }


        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        // The "ForeignKey" attribute tells SQL server that, the Product class is a Foreign class. 
        [ForeignKey("Product")]
     
      public ICollection<Product> Products { get; set; }

    }
}
