using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using TeaProject.DataAccess.Repository;
using TeaProject.DataAccess.Repository.IRepositity;
using TeaProject.Models;
using TeaProject.Models.Models;
using TeaProject.Models.ViewModels;
using System.Linq;

namespace TeaProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //IEnumerable<Product> productList =
            //   _unitOfWork.ProductRepository.GetAll();
            var productList = _unitOfWork.ProductRepository.GetAll();
            var viewModel = new ShoppingCartVM
            {
                ProductList = productList
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
     
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (shoppingCart.ApplicationUserId == null)
            {
                shoppingCart.ApplicationUser.Id = userId;
            }
         
                ShoppingCart cartfromDb = _unitOfWork.ShoppingCartRepository.Get(u => u.ApplicationUser.Id
           == userId && u.ProductId == shoppingCart.ProductId && u.Ice == shoppingCart.Ice &&
           u.Sweetness == shoppingCart.Sweetness && u.Toppings == shoppingCart.Toppings);
                if (cartfromDb != null)
                {
                    //購物車已建立
                    cartfromDb.Count += shoppingCart.Count;

                }
                else
                {
                    _unitOfWork.ShoppingCartRepository.Add(shoppingCart);
                }
            
            TempData["success"] = "加入購物車成功";
            _unitOfWork.Save();
            
           
              return  RedirectToAction("Index");

        }
        // 根据产品ID获取产品信息
        [HttpGet]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound(); // 如果找不到产品，返回404
            }
            return Ok(product.Name); // 返回产品信息
        }

        // 根据产品ID和容量获取产品价格
        [HttpGet]
        public async Task<IActionResult> GetProductPrice(int productId, string size)
        {
            var price = await _unitOfWork.ProductRepository.GetProductPriceAsync(productId, size);
            if (price == null)
            {
                return NotFound(); // 如果找不到产品或者价格，返回404
            }
            return Ok(price); // 返回产品价格
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

