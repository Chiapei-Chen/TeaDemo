using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeaProject.DataAccess.Repository.IRepositity;
using TeaProject.Models;
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
            return View();

        }
      
    }

}
