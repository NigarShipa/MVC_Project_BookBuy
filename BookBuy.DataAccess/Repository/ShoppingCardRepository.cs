using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBuy.DataAccess.Data;
using BookBuy.DataAccess.Repository.IRepository;
using BookBuy.Models;

namespace BookBuy.DataAccess.Repository
{
    public class ShoppingCardRepository : Repository<ShoppingCard>, IShoppingCardRepository
    {
        private ApplicationDbContext _db;

        public ShoppingCardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public int DecrementCount(ShoppingCard shoppingCard, int count)
        {
            shoppingCard.Count -= count;
            return shoppingCard.Count;
        }

        public int IncrementCount(ShoppingCard shoppingCard, int count)
        {
            shoppingCard.Count += count;
            return shoppingCard.Count;
        }
    }
}
