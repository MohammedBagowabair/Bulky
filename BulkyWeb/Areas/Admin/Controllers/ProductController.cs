using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objProductsList = _unitOfWork.Product.GetAll().ToList();

            return View(objProductsList);
        }

        public IActionResult Create()
        {


            ProductVM productVM = new()
            {
                Product = new Product { },
                CategoryList = _unitOfWork.Category.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })
            };

            return View(productVM);
        }
        [HttpPost]
        public IActionResult Create(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _unitOfWork.Category.GetAll().ToList().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            }

            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Updated successfully";
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
            Product? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();
            }
            return View(ProductFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound();

            }
            _unitOfWork.Product.Remove(ProductFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
