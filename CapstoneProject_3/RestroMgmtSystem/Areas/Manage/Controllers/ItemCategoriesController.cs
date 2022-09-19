using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestroMgmtSystem.Data;
using RestroMgmtSystem.Models;

namespace RestroMgmtSystem.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ItemCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Identity/ItemCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItemCategories.Include(i => i.Menu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Identity/ItemCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories
                .Include(i => i.Menu)
                .FirstOrDefaultAsync(m => m.ItemCategoryId == id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        // GET: Identity/ItemCategories/Create
        public IActionResult Create()
        {
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuName");
            return View();
        }

        // POST: Identity/ItemCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemCategoryId,ItemCategoryName,IsAvailable,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,ItemsAvailabel,MenuId")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuName", itemCategory.MenuId);
            return View(itemCategory);
        }

        // GET: Identity/ItemCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuName", itemCategory.MenuId);
            return View(itemCategory);
        }

        // POST: Identity/ItemCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemCategoryId,ItemCategoryName,IsAvailable,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate,ItemsAvailabel,MenuId")] ItemCategory itemCategory)
        {
            if (id != itemCategory.ItemCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCategoryExists(itemCategory.ItemCategoryId))
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
            ViewData["MenuId"] = new SelectList(_context.Menus, "MenuId", "MenuName", itemCategory.MenuId);
            return View(itemCategory);
        }

        // GET: Identity/ItemCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories
                .Include(i => i.Menu)
                .FirstOrDefaultAsync(m => m.ItemCategoryId == id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        // POST: Identity/ItemCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemCategory = await _context.ItemCategories.FindAsync(id);
            _context.ItemCategories.Remove(itemCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCategoryExists(int id)
        {
            return _context.ItemCategories.Any(e => e.ItemCategoryId == id);
        }
    }
}
