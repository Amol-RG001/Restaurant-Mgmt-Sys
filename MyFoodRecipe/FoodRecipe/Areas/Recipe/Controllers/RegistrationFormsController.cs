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
    public class RegistrationFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrationFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipe/RegistrationForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResgistrationForm.ToListAsync());
        }

        // GET: Recipe/RegistrationForms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationForm = await _context.ResgistrationForm
                .FirstOrDefaultAsync(m => m.ParticipantId == id);
            if (registrationForm == null)
            {
                return NotFound();
            }

            return View(registrationForm);
        }

        // GET: Recipe/RegistrationForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipe/RegistrationForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParticipantId,ParticipantName,PhoneNumer,Email,Address")] RegistrationForm registrationForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrationForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(registrationForm);
        }

        // GET: Recipe/RegistrationForms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationForm = await _context.ResgistrationForm.FindAsync(id);
            if (registrationForm == null)
            {
                return NotFound();
            }
            return View(registrationForm);
        }

        // POST: Recipe/RegistrationForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParticipantId,ParticipantName,PhoneNumer,Email,Address")] RegistrationForm registrationForm)
        {
            if (id != registrationForm.ParticipantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrationForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationFormExists(registrationForm.ParticipantId))
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
            return View(registrationForm);
        }

        // GET: Recipe/RegistrationForms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrationForm = await _context.ResgistrationForm
                .FirstOrDefaultAsync(m => m.ParticipantId == id);
            if (registrationForm == null)
            {
                return NotFound();
            }

            return View(registrationForm);
        }

        // POST: Recipe/RegistrationForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrationForm = await _context.ResgistrationForm.FindAsync(id);
            _context.ResgistrationForm.Remove(registrationForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationFormExists(int id)
        {
            return _context.ResgistrationForm.Any(e => e.ParticipantId == id);
        }
    }
}
