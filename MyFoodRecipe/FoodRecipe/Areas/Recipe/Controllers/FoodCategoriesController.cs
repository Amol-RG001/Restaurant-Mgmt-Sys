using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodRecipe.Data;
using FoodRecipe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace FoodRecipe.Areas.Recipe.Controllers
{
    [Area("Recipe")]
    [Authorize]
    public class FoodCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FoodCategoriesController> _logger;
        public FoodCategoriesController(ApplicationDbContext context, ILogger<FoodCategoriesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Recipe/FoodCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodCategory.ToListAsync());
        }
        public async Task<IActionResult> GetFoodsOfCategory(int filterFoodCategoryId )
        {
            var viewmodel = await _context.FoodCategory
                                          .Where(b => b.FoodCategoryId == filterFoodCategoryId) 
                                          .ToListAsync();

            return View(viewName: "IndexCustomized", model: viewmodel);
        }

        // GET: Recipe/FoodCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodCategory = await _context.FoodCategory
                .FirstOrDefaultAsync(m => m.FoodCategoryId == id);
            if (foodCategory == null)
            {
                return NotFound();
            }

            return View(foodCategory);
        }

        // GET: Recipe/FoodCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipe/FoodCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodCategoryId,FoodCategoryName")] FoodCategory foodCategory)
        {
           
            // Sanitize the data
            foodCategory.FoodCategoryName = foodCategory.FoodCategoryName.Trim();

            // Validation Checks - Server-side validation
            bool duplicateExists = _context.FoodCategory.Any(c => c.FoodCategoryName == foodCategory.FoodCategoryName);
            if (duplicateExists)
            {
                ModelState.AddModelError("FoodCategoryName", "Duplicate Category Found!");
            }
            if (ModelState.IsValid)
            {
                _context.FoodCategory.Add(foodCategory);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Created a New Category: ID = {foodCategory.FoodCategoryId} !");
                return RedirectToAction(nameof(Index));
            }

            return View(foodCategory);
        }

        // GET: Recipe/FoodCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodCategory = await _context.FoodCategory.FindAsync(id);
            if (foodCategory == null)
            {
                return NotFound();
            }
            return View(foodCategory);
        }

        // POST: Recipe/FoodCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodCategoryId,FoodCategoryName")] FoodCategory foodCategory)
        {
            if (id != foodCategory.FoodCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodCategoryExists(foodCategory.FoodCategoryId))
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
            return View(foodCategory);
        }

        // GET: Recipe/FoodCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodCategory = await _context.FoodCategory
                .FirstOrDefaultAsync(m => m.FoodCategoryId == id);
            if (foodCategory == null)
            {
                return NotFound();
            }

            return View(foodCategory);
        }

        // POST: Recipe/FoodCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodCategory = await _context.FoodCategory.FindAsync(id);
            _context.FoodCategory.Remove(foodCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodCategoryExists(int id)
        {
            return _context.FoodCategory.Any(e => e.FoodCategoryId == id);
        }
    }
}
