using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBuy.DataAccess.Data;
using BookBuy.DataAccess.Repository.IRepository;
using BookBuy.Models;
using Microsoft.AspNetCore.Identity;

namespace BookBuy.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

    }
    public class IdentityUserRepository : Repository<IdentityUser>, IIdentityUserRepository
    {
        private ApplicationDbContext _db;

        public IdentityUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

    }
}
