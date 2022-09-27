using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodRecipe.Data;
using FoodRecipe.Models;

namespace FoodRecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodSubCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FoodSubCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodSubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodSubCategory>>> GetFoodSubCategory()
        {
            return await _context.FoodSubCategory.ToListAsync();
        }

        // GET: api/FoodSubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodSubCategory>> GetFoodSubCategory(int id)
        {
            var foodSubCategory = await _context.FoodSubCategory.FindAsync(id);

            if (foodSubCategory == null)
            {
                return NotFound();
            }

            return foodSubCategory;
        }

        // PUT: api/FoodSubCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodSubCategory(int id, FoodSubCategory foodSubCategory)
        {
            if (id != foodSubCategory.FoodSubCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(foodSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodSubCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FoodSubCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FoodSubCategory>> PostFoodSubCategory(FoodSubCategory foodSubCategory)
        {
            _context.FoodSubCategory.Add(foodSubCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodSubCategory", new { id = foodSubCategory.FoodSubCategoryId }, foodSubCategory);
        }

        // DELETE: api/FoodSubCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodSubCategory>> DeleteFoodSubCategory(int id)
        {
            var foodSubCategory = await _context.FoodSubCategory.FindAsync(id);
            if (foodSubCategory == null)
            {
                return NotFound();
            }

            _context.FoodSubCategory.Remove(foodSubCategory);
            await _context.SaveChangesAsync();

            return foodSubCategory;
        }

        private bool FoodSubCategoryExists(int id)
        {
            return _context.FoodSubCategory.Any(e => e.FoodSubCategoryId == id);
        }
    }
}
