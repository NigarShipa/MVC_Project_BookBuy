using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBuy.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBuy.DataAccess.Repository.IRepository
{
    public interface IShoppingCardRepository : IRepository<ShoppingCard>
    {
        int IncrementCount(ShoppingCard shoppingCard, int count);

        int DecrementCount(ShoppingCard shoppingCard, int count);
    }
}
