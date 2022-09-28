using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodRecipe.Data;
using FoodRecipe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace FoodRecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FoodCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FoodCategoriesController> _logger; 

        public FoodCategoriesController(ApplicationDbContext context, 
            ILogger<FoodCategoriesController> logger)
        {
            _context = context;
            _logger = logger;   
        }

        // GET: api/FoodCategories
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<FoodCategory>>> GetFoodCategory()
        public async Task<ActionResult> GetFoodCategories()
        {
            try
            {

                var foodCategories = await _context.FoodCategory.ToListAsync();

                //check if data exists in the DB
                if (foodCategories == null)
                {
                    //No data Found - HTTP 404
                    return NotFound();
                }
                // RETURN: OkObjectResult - HTTP 200
                return Ok(foodCategories);
            }
            catch(Exception e)
            {
                // RETURN: BadResult - HTTP 400
                return BadRequest(e.Message);
            }
           
        }

        // GET: api/FoodCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodCategory>> GetFoodCategory(int id)
        {
            var foodCategory = await _context.FoodCategory.FindAsync(id);

            if (foodCategory == null)
            {
                return NotFound();
            }

            return foodCategory;
        }

        // PUT: api/FoodCategories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodCategory(int id, FoodCategory foodCategory)
        {
            if (id != foodCategory.FoodCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(foodCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodCategoryExists(id))
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

        // POST: api/FoodCategories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FoodCategory>> PostFoodCategory(FoodCategory foodCategory)
        {
            _context.FoodCategory.Add(foodCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodCategory", new { id = foodCategory.FoodCategoryId }, foodCategory);
        }

        // DELETE: api/FoodCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FoodCategory>> DeleteFoodCategory(int id)
        {
            var foodCategory = await _context.FoodCategory.FindAsync(id);
            if (foodCategory == null)
            {
                return NotFound();
            }

            _context.FoodCategory.Remove(foodCategory);
            await _context.SaveChangesAsync();

            return foodCategory;
        }

        private bool FoodCategoryExists(int id)
        {
            return _context.FoodCategory.Any(e => e.FoodCategoryId == id);
        }
    }
}
