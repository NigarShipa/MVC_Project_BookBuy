using System.Security.Claims;
using BookBuy.DataAccess.Repository.IRepository;
using BookBuy.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookBuyWeb.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claims != null)
            {
                if (HttpContext.Session.GetInt32(Sd.SessionCart) != null)
                {
                    return Task.FromResult<IViewComponentResult>(
                        View(HttpContext.Session.GetInt32(Sd.SessionCart)!.Value));
                }
                else
                {
                    var currentAddedItems = _unitOfWork.ShoppingCard
                        .GetAll(x => x.ApplicationUserId == claims.Value).ToList();

                    var itemCount = currentAddedItems.Count;

                    HttpContext.Session.SetInt32(Sd.SessionCart, itemCount);

                    return Task.FromResult<IViewComponentResult>(View(itemCount));
                }

            }
            else
            {
                return Task.FromResult<IViewComponentResult>(View(0));
            }

        }

    }
}
