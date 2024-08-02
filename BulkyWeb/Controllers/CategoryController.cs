
using Bulky.DataAccess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = db.Categories.ToList();
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
                db.Categories.Add(obj);
                db.SaveChanges();
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
            Category? CategoryFromDb = db.Categories.Find(id);
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
                db.Categories.Update(obj);
                db.SaveChanges();
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
            Category? CategoryFromDb = db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int?id)
        {
            Category? CategoryFromDb = db.Categories.Find(id);
            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            db.Categories.Remove(CategoryFromDb);
            db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
          
        }
    }
}