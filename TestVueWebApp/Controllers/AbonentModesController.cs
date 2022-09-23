using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestVueWebApp.Repository;
using TestVueWebApp.Repository.Models;

namespace TestVueWebApp.Controllers
{
    public class AbonentModesController : Controller
    {
        private readonly BillingDbContext _context;

        public AbonentModesController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: AbonentModes
        public async Task<IActionResult> Index()
        {
            var billingDbContext = _context.AbonentModes.Include(a => a.AccountCdNavigation).Include(a => a.ModeCdNavigation);
            return View(await billingDbContext.ToListAsync());
        }

        // GET: AbonentModes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonentMode = await _context.AbonentModes
                .Include(a => a.AccountCdNavigation)
                .Include(a => a.ModeCdNavigation)
                .FirstOrDefaultAsync(m => m.AbonentModeСd == id);
            if (abonentMode == null)
            {
                return NotFound();
            }

            return View(abonentMode);
        }

        // GET: AbonentModes/Create
        public IActionResult Create()
        {
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd");
            ViewData["ModeCd"] = new SelectList(_context.Modes, "ModeCd", "ModeName");
            return View();
        }

        // POST: AbonentModes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AbonentModeСd,AccountCd,ModeCd,Counterr")] AbonentMode abonentMode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(abonentMode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd", abonentMode.AccountCd);
            ViewData["ModeCd"] = new SelectList(_context.Modes, "ModeCd", "ModeName", abonentMode.ModeCd);
            return View(abonentMode);
        }

        // GET: AbonentModes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonentMode = await _context.AbonentModes.FindAsync(id);
            if (abonentMode == null)
            {
                return NotFound();
            }
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd", abonentMode.AccountCd);
            ViewData["ModeCd"] = new SelectList(_context.Modes, "ModeCd", "ModeName", abonentMode.ModeCd);
            return View(abonentMode);
        }

        // POST: AbonentModes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AbonentModeСd,AccountCd,ModeCd,Counterr")] AbonentMode abonentMode)
        {
            if (id != abonentMode.AbonentModeСd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(abonentMode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbonentModeExists(abonentMode.AbonentModeСd))
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
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd", abonentMode.AccountCd);
            ViewData["ModeCd"] = new SelectList(_context.Modes, "ModeCd", "ModeName", abonentMode.ModeCd);
            return View(abonentMode);
        }

        // GET: AbonentModes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonentMode = await _context.AbonentModes
                .Include(a => a.AccountCdNavigation)
                .Include(a => a.ModeCdNavigation)
                .FirstOrDefaultAsync(m => m.AbonentModeСd == id);
            if (abonentMode == null)
            {
                return NotFound();
            }

            return View(abonentMode);
        }

        // POST: AbonentModes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var abonentMode = await _context.AbonentModes.FindAsync(id);
            if (!_context.NachislSummas.Any(x => x.AbonentModeСd == id) && !_context.PaySummas.Any(x => x.AbonentModeСd == id))
            {
                _context.AbonentModes.Remove(abonentMode);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AbonentModeExists(int id)
        {
            return _context.AbonentModes.Any(e => e.AbonentModeСd == id);
        }
    }
}
