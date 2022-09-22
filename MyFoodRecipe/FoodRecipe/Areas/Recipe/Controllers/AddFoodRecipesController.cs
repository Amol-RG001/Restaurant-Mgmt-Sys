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
    public class AddFoodRecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddFoodRecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipe/AddFoodRecipes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AddFoodRecipe.Include(a => a.FoodSubCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recipe/AddFoodRecipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addFoodRecipe = await _context.AddFoodRecipe
                .Include(a => a.FoodSubCategory)
                .FirstOrDefaultAsync(m => m.FoodRecipeId == id);
            if (addFoodRecipe == null)
            {
                return NotFound();
            }

            return View(addFoodRecipe);
        }

        // GET: Recipe/AddFoodRecipes/Create
        public IActionResult Create()
        {
            ViewData["FoodSubCategoryId"] = new SelectList(_context.FoodSubCategory, "FoodSubCategoryId", "FoodSubCategoryName");
            return View();
        }

        // POST: Recipe/AddFoodRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodRecipeId,FoodRecipeName,FoodIngredient,FoodMakingStep,FoodSubCategoryId")] AddFoodRecipe addFoodRecipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addFoodRecipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FoodSubCategoryId"] = new SelectList(_context.FoodSubCategory, "FoodSubCategoryId", "FoodSubCategoryName", addFoodRecipe.FoodSubCategoryId);
            return View(addFoodRecipe);
        }

        // GET: Recipe/AddFoodRecipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addFoodRecipe = await _context.AddFoodRecipe.FindAsync(id);
            if (addFoodRecipe == null)
            {
                return NotFound();
            }
            ViewData["FoodSubCategoryId"] = new SelectList(_context.FoodSubCategory, "FoodSubCategoryId", "FoodSubCategoryName", addFoodRecipe.FoodSubCategoryId);
            return View(addFoodRecipe);
        }

        // POST: Recipe/AddFoodRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodRecipeId,FoodRecipeName,FoodIngredient,FoodMakingStep,FoodSubCategoryId")] AddFoodRecipe addFoodRecipe)
        {
            if (id != addFoodRecipe.FoodRecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addFoodRecipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddFoodRecipeExists(addFoodRecipe.FoodRecipeId))
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
            ViewData["FoodSubCategoryId"] = new SelectList(_context.FoodSubCategory, "FoodSubCategoryId", "FoodSubCategoryName", addFoodRecipe.FoodSubCategoryId);
            return View(addFoodRecipe);
        }

        // GET: Recipe/AddFoodRecipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addFoodRecipe = await _context.AddFoodRecipe
                .Include(a => a.FoodSubCategory)
                .FirstOrDefaultAsync(m => m.FoodRecipeId == id);
            if (addFoodRecipe == null)
            {
                return NotFound();
            }

            return View(addFoodRecipe);
        }

        // POST: Recipe/AddFoodRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addFoodRecipe = await _context.AddFoodRecipe.FindAsync(id);
            _context.AddFoodRecipe.Remove(addFoodRecipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddFoodRecipeExists(int id)
        {
            return _context.AddFoodRecipe.Any(e => e.FoodRecipeId == id);
        }
    }
}
