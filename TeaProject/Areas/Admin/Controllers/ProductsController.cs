using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeaProject.DataAccess.Data;
using TeaProject.DataAccess.Repository.IRepositity;
using TeaProject.Models;
using TeaProject.Models.ViewModels;

namespace TeaProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        // GET: Admin/Products
        public IActionResult Index()
        {

            List<Product> objCategoryList = _unitOfWork.ProductRepository.GetAll().ToList();
            return View(objCategoryList);
        }



        public IActionResult Upsert(int? id) {

            // 建立 ProductVM 物件
            var productVM = new ProductVM
            {
                Product = new Product(),
                CategoryList = _unitOfWork.CategoryRepository.GetAll()
                                    .Select(c => new SelectListItem
                                    {
                                        Text = c.Name,
                                        Value = c.Id.ToString()
                                    })
            };
            if (id == null || id == 0)
            {
                //新增
                return View(productVM);
            }
            else {
                //編輯
                productVM.Product = _unitOfWork.ProductRepository.Get(u => u.Id == id);
            }
            return View(productVM);
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                if (productVM.Product.Id == 0|| productVM.Product.Id==null)
                {
                    _unitOfWork.ProductRepository.Add(productVM.Product);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    productVM.CategoryList =
                     _unitOfWork.CategoryRepository.GetAll().Select(c =>
                     new SelectListItem {
                     
                         Text = c.Name,
                         Value = c.Id.ToString()
                     });
                    productVM.Product=new Product{ 
                     Size=productVM.Product.Size,
                     Name=productVM.Product.Name,
                     Price=productVM.Product.Price,
                     Temperature=productVM.Product.Temperature,
                     CategoryId=productVM.Product.CategoryId,
                    };
                    _unitOfWork.ProductRepository.Update(productVM.Product);
                    _unitOfWork.Save();
                    return RedirectToAction("Index");
                }

              
                
            }
       
         
            return View(productVM);
        }
     


        // GET: Admin/Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            Product productFromDb = _unitOfWork.ProductRepository.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Product productFromDb = _unitOfWork.ProductRepository.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepository.Remove(productFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool ProductExists(int id)
        //{
        //    return _unitOfWork.ProductRepository.Any(e => e.Id == id);
        //}
    }
}
