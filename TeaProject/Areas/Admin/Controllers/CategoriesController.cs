using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeaProject.DataAccess.Data;
using TeaProject.DataAccess.Repository.IRepositity;
using TeaProject.Models;
using TeaProject.Utility;

namespace TeaProject.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles=SD.Role_Admin)]
	public class CategoriesController : Controller
    {
        //Area
      

        //private readonly TeaProject0504Context _context;
        //private readonly ICategoryRepository _categoryRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Categories
        public IActionResult Index()
        {
            //這裡
            List<Category> categories = _unitOfWork.CategoryRepository.GetAll().ToList();
            return View(categories);
        }


        // GET: Categories/Create
        public IActionResult Upsert()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Add(category);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //這裡
            Category? categoryFromDb = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();



                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category categoryFromDb = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Category obj = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoryRepository.Remove(obj);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

       
    }
}
