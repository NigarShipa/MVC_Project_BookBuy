using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class ShoppingCard
    {
        public Product product { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter with valid range")]
        public int Count { get; set; }

    }
}
