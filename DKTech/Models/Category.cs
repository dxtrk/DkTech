
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace DKTech.Models
{
    public class Category
    {

        public int CategoryID { get; set; }


        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

