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
    public class FoodEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FoodEventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipe/FoodEvents
        public async Task<IActionResult> Index()
        {
            return View(await _context.FoodEvent.ToListAsync());
        }

        // GET: Recipe/FoodEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodEvent = await _context.FoodEvent
                .FirstOrDefaultAsync(m => m.EventNo == id);
            if (foodEvent == null)
            {
                return NotFound();
            }

            return View(foodEvent);
        }

        // GET: Recipe/FoodEvents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipe/FoodEvents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventNo,EventName,Description,EventDateTime")] FoodEvent foodEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodEvent);
        }

        // GET: Recipe/FoodEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodEvent = await _context.FoodEvent.FindAsync(id);
            if (foodEvent == null)
            {
                return NotFound();
            }
            return View(foodEvent);
        }

        // POST: Recipe/FoodEvents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventNo,EventName,Description,EventDateTime")] FoodEvent foodEvent)
        {
            if (id != foodEvent.EventNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodEventExists(foodEvent.EventNo))
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
            return View(foodEvent);
        }

        // GET: Recipe/FoodEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodEvent = await _context.FoodEvent
                .FirstOrDefaultAsync(m => m.EventNo == id);
            if (foodEvent == null)
            {
                return NotFound();
            }

            return View(foodEvent);
        }

        // POST: Recipe/FoodEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodEvent = await _context.FoodEvent.FindAsync(id);
            _context.FoodEvent.Remove(foodEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodEventExists(int id)
        {
            return _context.FoodEvent.Any(e => e.EventNo == id);
        }
    }
}
