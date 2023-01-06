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
    public class Categoryrepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public Categoryrepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
