using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodRecipe.Data;
using FoodRecipe.Models;

namespace FoodRecipe.Areas.Recipe.Controllers
{
    [Area("Recipe")]
    public class FoodSubCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodSubCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipe/FoodSubCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FoodSubCategory.Include(f => f.FoodCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> GetFoodsOfCategory(int filterFoodCategoryId)
        {
            var viewmodel = await _context.FoodSubCategory
                                          .Where(b => b.FoodSubCategoryId == filterFoodCategoryId)
                                          .ToListAsync();

            return View(viewName: "IndexCustomized", model: viewmodel);
        }

        // GET: Recipe/FoodSubCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodSubCategory = await _context.FoodSubCategory
                .Include(f => f.FoodCategory)
                .FirstOrDefaultAsync(m => m.FoodSubCategoryId == id);
            if (foodSubCategory == null)
            {
                return NotFound();
            }

            return View(foodSubCategory);
        }

        // GET: Recipe/FoodSubCategories/Create
        public IActionResult Create()
        {
            ViewData["FoodCategoryId"] = new SelectList(_context.FoodCategory, "FoodCategoryId", "FoodCategoryName");
            return View();
        }

        // POST: Recipe/FoodSubCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodSubCategoryId,FoodSubCategoryName,FoodCategoryId")] FoodSubCategory foodSubCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodSubCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodCategoryId"] = new SelectList(_context.FoodCategory, "FoodCategoryId", "FoodCategoryName", foodSubCategory.FoodCategoryId);
            return View(foodSubCategory);
        }

        // GET: Recipe/FoodSubCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodSubCategory = await _context.FoodSubCategory.FindAsync(id);
            if (foodSubCategory == null)
            {
                return NotFound();
            }
            ViewData["FoodCategoryId"] = new SelectList(_context.FoodCategory, "FoodCategoryId", "FoodCategoryName", foodSubCategory.FoodCategoryId);
            return View(foodSubCategory);
        }

        // POST: Recipe/FoodSubCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodSubCategoryId,FoodSubCategoryName,FoodCategoryId")] FoodSubCategory foodSubCategory)
        {
            if (id != foodSubCategory.FoodSubCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodSubCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodSubCategoryExists(foodSubCategory.FoodSubCategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodCategoryId"] = new SelectList(_context.FoodCategory, "FoodCategoryId", "FoodCategoryName", foodSubCategory.FoodCategoryId);
            return View(foodSubCategory);
        }

        // GET: Recipe/FoodSubCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodSubCategory = await _context.FoodSubCategory
                .Include(f => f.FoodCategory)
                .FirstOrDefaultAsync(m => m.FoodSubCategoryId == id);
            if (foodSubCategory == null)
            {
                return NotFound();
            }

            return View(foodSubCategory);
        }

        // POST: Recipe/FoodSubCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodSubCategory = await _context.FoodSubCategory.FindAsync(id);
            _context.FoodSubCategory.Remove(foodSubCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodSubCategoryExists(int id)
        {
            return _context.FoodSubCategory.Any(e => e.FoodSubCategoryId == id);
        }
    }
}
