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
    public class AddFoodRecipesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AddFoodRecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AddFoodRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddFoodRecipe>>> GetAddFoodRecipe()
        {
            return await _context.AddFoodRecipe.ToListAsync();
        }

        // GET: api/AddFoodRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddFoodRecipe>> GetAddFoodRecipe(int id)
        {
            var addFoodRecipe = await _context.AddFoodRecipe.FindAsync(id);

            if (addFoodRecipe == null)
            {
                return NotFound();
            }

            return addFoodRecipe;
        }

        // PUT: api/AddFoodRecipes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddFoodRecipe(int id, AddFoodRecipe addFoodRecipe)
        {
            if (id != addFoodRecipe.FoodRecipeId)
            {
                return BadRequest();
            }

            _context.Entry(addFoodRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddFoodRecipeExists(id))
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

        // POST: api/AddFoodRecipes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AddFoodRecipe>> PostAddFoodRecipe(AddFoodRecipe addFoodRecipe)
        {
            _context.AddFoodRecipe.Add(addFoodRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddFoodRecipe", new { id = addFoodRecipe.FoodRecipeId }, addFoodRecipe);
        }

        // DELETE: api/AddFoodRecipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AddFoodRecipe>> DeleteAddFoodRecipe(int id)
        {
            var addFoodRecipe = await _context.AddFoodRecipe.FindAsync(id);
            if (addFoodRecipe == null)
            {
                return NotFound();
            }

            _context.AddFoodRecipe.Remove(addFoodRecipe);
            await _context.SaveChangesAsync();

            return addFoodRecipe;
        }

        private bool AddFoodRecipeExists(int id)
        {
            return _context.AddFoodRecipe.Any(e => e.FoodRecipeId == id);
        }
    }
}
