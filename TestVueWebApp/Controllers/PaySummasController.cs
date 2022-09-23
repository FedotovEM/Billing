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
    public class PaySummasController : Controller
    {
        private readonly BillingDbContext _context;

        public PaySummasController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: PaySummas
        public async Task<IActionResult> Index()
        {
            var billingDbContext = _context.PaySummas.Include(p => p.AbonentModeСdNavigation).Include(p => p.ReceptionPointCdNavigation);
            return View(await billingDbContext.ToListAsync());
        }

        // GET: PaySummas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paySumma = await _context.PaySummas
                .Include(p => p.AbonentModeСdNavigation)
                .Include(p => p.ReceptionPointCdNavigation)
                .FirstOrDefaultAsync(m => m.PayFactCd == id);
            if (paySumma == null)
            {
                return NotFound();
            }

            return View(paySumma);
        }

        // GET: PaySummas/Create
        public IActionResult Create()
        {
            ViewData["AbonentModeСd"] = new SelectList(_context.AbonentModes, "AbonentModeСd", "AccountCd");
            ViewData["ReceptionPointCd"] = new SelectList(_context.ReceptionPoints, "ReceptionPointCd", "ReceptionName");
            return View();
        }

        // POST: PaySummas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayFactCd,PaySum,PayDate,PayMonth,PayYear,AbonentModeСd,PayType,ReceptionPointCd")] PaySumma paySumma)
        {
            if (ModelState.IsValid)
            {
                if (PaySummaAllRight(paySumma))
                {
                    _context.Add(paySumma);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            ViewData["AbonentModeСd"] = new SelectList(_context.AbonentModes, "AbonentModeСd", "AccountCd", paySumma.AbonentModeСd);
            ViewData["ReceptionPointCd"] = new SelectList(_context.ReceptionPoints, "ReceptionPointCd", "ReceptionName", paySumma.ReceptionPointCd);
            return View(paySumma);
        }

        // GET: PaySummas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paySumma = await _context.PaySummas.FindAsync(id);
            if (paySumma == null)
            {
                return NotFound();
            }
            ViewData["AbonentModeСd"] = new SelectList(_context.AbonentModes, "AbonentModeСd", "AccountCd", paySumma.AbonentModeСd);
            ViewData["ReceptionPointCd"] = new SelectList(_context.ReceptionPoints, "ReceptionPointCd", "ReceptionName", paySumma.ReceptionPointCd);
            return View(paySumma);
        }

        // POST: PaySummas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PayFactCd,PaySum,PayDate,PayMonth,PayYear,AbonentModeСd,PayType,ReceptionPointCd")] PaySumma paySumma)
        {
            if (id != paySumma.PayFactCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (PaySummaAllRight(paySumma))
                    {
                        _context.Update(paySumma);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaySummaExists(paySumma.PayFactCd))
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
            ViewData["AbonentModeСd"] = new SelectList(_context.AbonentModes, "AbonentModeСd", "AccountCd", paySumma.AbonentModeСd);
            ViewData["ReceptionPointCd"] = new SelectList(_context.ReceptionPoints, "ReceptionPointCd", "ReceptionName", paySumma.ReceptionPointCd);
            return View(paySumma);
        }

        // GET: PaySummas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paySumma = await _context.PaySummas
                .Include(p => p.AbonentModeСdNavigation)
                .Include(p => p.ReceptionPointCdNavigation)
                .FirstOrDefaultAsync(m => m.PayFactCd == id);
            if (paySumma == null)
            {
                return NotFound();
            }

            return View(paySumma);
        }

        // POST: PaySummas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paySumma = await _context.PaySummas.FindAsync(id);
            _context.PaySummas.Remove(paySumma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaySummaExists(int id)
        {
            return _context.PaySummas.Any(e => e.PayFactCd == id);
        }

        private bool PaySummaAllRight(PaySumma _paySumma)
        {
            bool PaySumAllRight;
            if (_paySumma.PaySum >= 0)
                PaySumAllRight = true;
            else
                PaySumAllRight = false;

            bool PayYearAllRight;
            if (_paySumma.PayYear >= 1990 && _paySumma.PayYear <= DateTime.Now.Year)
                PayYearAllRight = true;
            else
                PayYearAllRight = false;

            bool PayMonthAllRight;
            if (_paySumma.PayMonth >= 1 && _paySumma.PayMonth <= 12)
                PayMonthAllRight = true;
            else
                PayMonthAllRight = false;

            bool PayTypeAllRight;
            if (_paySumma.PayType != null)
                PayTypeAllRight = Regex.IsMatch(_paySumma.PayType, @"^[^a-zA-Z0-9]+$");
            else
                PayTypeAllRight = false;

            bool PayDateAllRight;
            if (_paySumma.PayDate <= DateTime.Now)
                PayDateAllRight = true;
            else
                PayDateAllRight = false;


            bool Result = PaySumAllRight && PayYearAllRight && PayMonthAllRight && PayTypeAllRight && PayDateAllRight;
            return Result;
        }
    }
}
