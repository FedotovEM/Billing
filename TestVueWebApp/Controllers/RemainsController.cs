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
    public class RemainsController : Controller
    {
        private readonly BillingDbContext _context;

        public RemainsController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: Remains
        public async Task<IActionResult> Index()
        {
            var billingDbContext = _context.Remains.Include(r => r.AccountCdNavigation).Include(r => r.ServiceCdNavigation);
            return View(await billingDbContext.ToListAsync());
        }

        // GET: Remains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remain = await _context.Remains
                .Include(r => r.AccountCdNavigation)
                .Include(r => r.ServiceCdNavigation)
                .FirstOrDefaultAsync(m => m.RemainCd == id);
            if (remain == null)
            {
                return NotFound();
            }

            return View(remain);
        }

        // GET: Remains/Create
        public IActionResult Create()
        {
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd");
            ViewData["ServiceCd"] = new SelectList(_context.Services, "ServiceCd", "ServiceName");
            return View();
        }

        // POST: Remains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RemainCd,AccountCd,ServiceCd,Remmonth,Remyear,Remainsum")] Remain remain)
        {
            if (ModelState.IsValid)
            {
                if (RemainAllRight(remain))
                {
                    _context.Add(remain);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd", remain.AccountCd);
            ViewData["ServiceCd"] = new SelectList(_context.Services, "ServiceCd", "ServiceName", remain.ServiceCd);
            return View(remain);
        }

        // GET: Remains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remain = await _context.Remains.FindAsync(id);
            if (remain == null)
            {
                return NotFound();
            }
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd", remain.AccountCd);
            ViewData["ServiceCd"] = new SelectList(_context.Services, "ServiceCd", "ServiceName", remain.ServiceCd);
            return View(remain);
        }

        // POST: Remains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RemainCd,AccountCd,ServiceCd,Remmonth,Remyear,Remainsum")] Remain remain)
        {
            if (id != remain.RemainCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (RemainAllRight(remain))
                    {
                        _context.Update(remain);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RemainExists(remain.RemainCd))
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
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd", remain.AccountCd);
            ViewData["ServiceCd"] = new SelectList(_context.Services, "ServiceCd", "ServiceName", remain.ServiceCd);
            return View(remain);
        }

        // GET: Remains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var remain = await _context.Remains
                .Include(r => r.AccountCdNavigation)
                .Include(r => r.ServiceCdNavigation)
                .FirstOrDefaultAsync(m => m.RemainCd == id);
            if (remain == null)
            {
                return NotFound();
            }

            return View(remain);
        }

        // POST: Remains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var remain = await _context.Remains.FindAsync(id);
            _context.Remains.Remove(remain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RemainExists(int id)
        {
            return _context.Remains.Any(e => e.RemainCd == id);
        }

        private bool RemainAllRight(Remain _remain)
        {
            bool RemyearAllRight;
            if (_remain.Remyear >= 1990 && _remain.Remyear <= DateTime.Now.Year)
                RemyearAllRight = true;
            else
                RemyearAllRight = false;

            bool RemmonthAllRight;
            if (_remain.Remmonth >= 1 && _remain.Remmonth <= 12)
                RemmonthAllRight = true;
            else
                RemmonthAllRight = false;

            bool Result = RemyearAllRight && RemmonthAllRight;
            return Result;
        }

    }
}
