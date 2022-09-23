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
    public class NachislSummasController : Controller
    {
        private readonly BillingDbContext _context;

        public NachislSummasController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: NachislSummas
        public async Task<IActionResult> Index()
        {
            var billingDbContext = _context.NachislSummas.Include(n => n.AbonentModeСdNavigation);
            return View(await billingDbContext.ToListAsync());
        }

        // GET: NachislSummas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nachislSumma = await _context.NachislSummas
                .Include(n => n.AbonentModeСdNavigation)
                .FirstOrDefaultAsync(m => m.NachislFactCd == id);
            if (nachislSumma == null)
            {
                return NotFound();
            }

            return View(nachislSumma);
        }

        // GET: NachislSummas/Create
        public IActionResult Create()
        {
            ViewData["AbonentModeСd"] = new SelectList(_context.AbonentModes, "AbonentModeСd", "AccountCd");
            return View();
        }

        // POST: NachislSummas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NachislFactCd,NachislSum,NachislYear,NachislMonth,NachType,AbonentModeСd,CountResources")] NachislSumma nachislSumma)
        {
            if (ModelState.IsValid)
            {
                if (NachislSummaAllRight(nachislSumma))
                {
                    _context.Add(nachislSumma);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            ViewData["AbonentModeСd"] = new SelectList(_context.AbonentModes, "AbonentModeСd", "AccountCd", nachislSumma.AbonentModeСd);
            return View(nachislSumma);
        }

        // GET: NachislSummas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nachislSumma = await _context.NachislSummas.FindAsync(id);
            if (nachislSumma == null)
            {
                return NotFound();
            }
            ViewData["AbonentModeСd"] = new SelectList(_context.AbonentModes, "AbonentModeСd", "AccountCd", nachislSumma.AbonentModeСd);
            return View(nachislSumma);
        }

        // POST: NachislSummas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NachislFactCd,NachislSum,NachislYear,NachislMonth,NachType,AbonentModeСd,CountResources")] NachislSumma nachislSumma)
        {
            if (id != nachislSumma.NachislFactCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (NachislSummaAllRight(nachislSumma))
                    {
                        _context.Update(nachislSumma);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NachislSummaExists(nachislSumma.NachislFactCd))
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
            ViewData["AbonentModeСd"] = new SelectList(_context.AbonentModes, "AbonentModeСd", "AccountCd", nachislSumma.AbonentModeСd);
            return View(nachislSumma);
        }

        // GET: NachislSummas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nachislSumma = await _context.NachislSummas
                .Include(n => n.AbonentModeСdNavigation)
                .FirstOrDefaultAsync(m => m.NachislFactCd == id);
            if (nachislSumma == null)
            {
                return NotFound();
            }

            return View(nachislSumma);
        }

        // POST: NachislSummas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nachislSumma = await _context.NachislSummas.FindAsync(id);
            _context.NachislSummas.Remove(nachislSumma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NachislSummaExists(int id)
        {
            return _context.NachislSummas.Any(e => e.NachislFactCd == id);
        }

        private bool NachislSummaAllRight(NachislSumma _nachislSumma)
        {
            bool NachislSumAllRight;
            if (_nachislSumma.NachislSum >= 0)
                NachislSumAllRight = true;
            else
                NachislSumAllRight = false;

            bool NachislYearAllRight;
            if (_nachislSumma.NachislYear >= 1990 && _nachislSumma.NachislYear <= DateTime.Now.Year)
                NachislYearAllRight = true;
            else
                NachislYearAllRight = false;

            bool NachislMonthAllRight;
            if (_nachislSumma.NachislMonth >= 1 && _nachislSumma.NachislMonth <= 12)
                NachislMonthAllRight = true;
            else
                NachislMonthAllRight = false;

            bool NachTypeAllRight;
            if (_nachislSumma.NachType != null)
                NachTypeAllRight = Regex.IsMatch(_nachislSumma.NachType, @"^[^a-zA-Z0-9]+$");
            else
                NachTypeAllRight = false;

            bool CountResourcesAllRight;
            if (_nachislSumma.CountResources >= 0)
                CountResourcesAllRight = true;
            else
                CountResourcesAllRight = false;

            
            bool Result = NachislSumAllRight && NachislYearAllRight && NachislMonthAllRight && NachTypeAllRight && CountResourcesAllRight;
            return Result;
        }

    }
}
