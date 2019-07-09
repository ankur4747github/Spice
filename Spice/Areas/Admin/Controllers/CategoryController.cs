using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //GET
        public async Task<IActionResult> Index()
        {
            return View(await _db.Categorie.ToListAsync());
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categorie.Add(category);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _db.Categorie.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Update(category);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        //GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _db.Categorie.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //POST - Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var category = await _db.Categorie.FindAsync(id);
            if (category == null)
            {
                return View();
            }
            _db.Categorie.Remove(category);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET - DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _db.Categorie.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
    }
}