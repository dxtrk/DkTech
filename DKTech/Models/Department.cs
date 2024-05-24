
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace DKTech.Models
{
    public class Category
    {

        public int Category_ID { get; set; }


        [Required]
        [StringLength(100)]
        public required string Category_name { get; set; }

        public required ICollection<Products> Products { get; set; }
    }
}

