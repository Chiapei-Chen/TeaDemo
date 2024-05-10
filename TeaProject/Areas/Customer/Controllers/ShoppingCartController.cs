using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeaProject.DataAccess.Repository.IRepositity;
using TeaProject.Models.ViewModels;

namespace TeaProject.Areas.Customer.Controllers
{
    [Area("Customers")]
    [Authorize] //通過身分驗證才可以訪問
    public class ShoppingCartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity=(ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst
            (ClaimTypes.NameIdentifier).Value;
            ShoppingCartVM = new()
            {
                ShoppingCartList=_unitOfWork.ShoppingCartRepository
                .GetAll(u=>u.ApplicationUserId==userId,includeProperties:"Product")

            };
            foreach (var cart in ShoppingCartVM.ShoppingCartList) {
                ShoppingCartVM.OrderTotal += (double)(cart.Product.Price * cart.Count);
            }
            return View(ShoppingCartVM);

          
        }
    }
}
