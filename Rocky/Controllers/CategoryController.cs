using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            IEnumerable<Category> catgories = _db.Category;
;
            return View(catgories);
        }


        //Get - Create
        public IActionResult Create()
        {           
            return View();
        }

        //Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid) // валидация на стороне сервера
            {
                _db.Category.Add(category);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);
           
        }

        //Get - EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Category.Find(id);
            if(category == null)
                return NotFound();  

            return View(category);
        }
    }
}
