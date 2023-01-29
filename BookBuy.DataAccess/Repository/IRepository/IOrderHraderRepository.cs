using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBuy.Models;
using Microsoft.EntityFrameworkCore;

namespace BookBuy.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentIntentId = null);
        void UpdateStripeId(int id, string sessionId, string paymentIntentId);

    }
}
