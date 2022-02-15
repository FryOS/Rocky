using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _db.Product;

            foreach (var product in products)
            {
                  product.Category = _db.Category.FirstOrDefault(u => u.Id == product.CategoryId);
            };
            
            return View(products);
        }


        //Get - Upsert
        public IActionResult Create()
        {
            return View();
        }

        //Get - Upsert
        public IActionResult Upsert(int? id) //если редактируем то передаем id
        {
            IEnumerable<SelectListItem> CategoryDropDown = _db.Category.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            ViewBag.CategoryDropDown = CategoryDropDown;    

            Product product = new Product();
            if (id == null)
            {
                return View(product);
            }
            else
            {
                product = _db.Product.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }

        //delete

        //Get - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _db.Category.Find(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        //Post - Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var category = _db.Category.Find(id);
            if (category == null)
            {
                return NotFound();
            }
                _db.Category.Remove(category);
                _db.SaveChanges();
                return RedirectToAction("Index");    
        }


    }
}
