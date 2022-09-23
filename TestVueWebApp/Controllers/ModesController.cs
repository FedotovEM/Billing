using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestVueWebApp.Repository;
using TestVueWebApp.Repository.Models;

namespace TestVueWebApp.Controllers
{
    public class ModesController : Controller
    {
        private readonly BillingDbContext _context;

        public ModesController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: Modes
        public async Task<IActionResult> Index()
        {
            var billingDbContext = _context.Modes.Include(m => m.ServiceCdNavigation);
            return View(await billingDbContext.ToListAsync());
        }

        // GET: Modes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mode = await _context.Modes
                .Include(m => m.ServiceCdNavigation)
                .FirstOrDefaultAsync(m => m.ModeCd == id);
            if (mode == null)
            {
                return NotFound();
            }

            return View(mode);
        }

        // GET: Modes/Create
        public IActionResult Create()
        {
            ViewData["ServiceCd"] = new SelectList(_context.Services, "ServiceCd", "ServiceName");
            return View();
        }

        // POST: Modes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModeCd,ModeName,Norma,ServiceCd")] Mode mode)
        {
            if (ModelState.IsValid)
            {
                if (ModeAllRight(mode))
                {
                    _context.Add(mode);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            ViewData["ServiceCd"] = new SelectList(_context.Services, "ServiceCd", "ServiceName", mode.ServiceCd);
            return View(mode);
        }

        // GET: Modes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mode = await _context.Modes.FindAsync(id);
            if (mode == null)
            {
                return NotFound();
            }
            ViewData["ServiceCd"] = new SelectList(_context.Services, "ServiceCd", "ServiceName", mode.ServiceCd);
            return View(mode);
        }

        // POST: Modes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModeCd,ModeName,Norma,ServiceCd")] Mode mode)
        {
            if (id != mode.ModeCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ModeAllRight(mode))
                    {
                        _context.Update(mode);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeExists(mode.ModeCd))
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
            ViewData["ServiceCd"] = new SelectList(_context.Services, "ServiceCd", "ServiceName", mode.ServiceCd);
            return View(mode);
        }

        // GET: Modes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mode = await _context.Modes
                .Include(m => m.ServiceCdNavigation)
                .FirstOrDefaultAsync(m => m.ModeCd == id);
            if (mode == null)
            {
                return NotFound();
            }

            return View(mode);
        }

        // POST: Modes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mode = await _context.Modes.FindAsync(id);
            if (!_context.Prices.Any(x => x.ModeCd == id) && !_context.AbonentModes.Any(x => x.ModeCd == id))
            {
                _context.Modes.Remove(mode);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ModeExists(int id)
        {
            return _context.Modes.Any(e => e.ModeCd == id);
        }

        private bool ModeAllRight(Mode _mode)
        {
            bool NormaAllRight;
            if (_mode.Norma >= 0)
                NormaAllRight = true;
            else
                NormaAllRight = false;

            bool ModeNameAllRight;
            if (_mode.ModeName != null)
                ModeNameAllRight = Regex.IsMatch(_mode.ModeName.ToString(), @"^[^a-zA-Z]+$");
            else
                ModeNameAllRight = false;


            bool Result = NormaAllRight && ModeNameAllRight;
            return Result;
        }

    }
}
