using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class Itemrepository : Repository<Item>, IItemRepository
    {
        private ApplicationDbContext _db;

        public Itemrepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Item obj)
        {
            _db.Products.Update(obj);
        }
    }
}
