using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly AppDbContext _db;

        public ApplicationTypeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> catgories = _db.ApplicationType;

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
        public IActionResult Create(ApplicationType applicationType)
        {
            if (ModelState.IsValid) // валидация на стороне сервера
            {
                _db.ApplicationType.Add(applicationType);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(applicationType);

        }

        //Get - EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var app = _db.ApplicationType.Find(id);
            if (app == null)
                return NotFound();

            return View(app);
        }

        //Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType applicationType)
        {
            if (ModelState.IsValid) // валидация на стороне сервера
            {
                _db.ApplicationType.Update(applicationType);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(applicationType);

        }
        //delete

        //Get - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var app = _db.ApplicationType.Find(id);
            if (app == null)
                return NotFound();

            return View(app);
        }

        //Post - Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var app = _db.ApplicationType.Find(id);
            if (app == null)
            {
                return NotFound();
            }
            _db.ApplicationType.Remove(app);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
