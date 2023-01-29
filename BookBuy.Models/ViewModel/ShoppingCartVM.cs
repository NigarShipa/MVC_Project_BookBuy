using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookBuy.Models.ViewModel
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCard> ListCart { get; set; }
        // public double CartTotal { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
