
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            this._categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Name Cannot Exactly Same The Display Order");
            //}
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult Edit(int?id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryFromDb = _categoryRepo.Get(u => u.Id==id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryFromDb = _categoryRepo.Get(u => u.Id == id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int?id)
        {
            Category? CategoryFromDb = _categoryRepo.Get(u => u.Id == id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            _categoryRepo.Remove(CategoryFromDb);
            _categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
          
        }
    }
}