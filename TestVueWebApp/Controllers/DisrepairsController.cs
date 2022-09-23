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
    public class DisrepairsController : Controller
    {
        private readonly BillingDbContext _context;

        public DisrepairsController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: Disrepairs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disrepairs.ToListAsync());
        }

        // GET: Disrepairs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disrepair = await _context.Disrepairs
                .FirstOrDefaultAsync(m => m.FailureCd == id);
            if (disrepair == null)
            {
                return NotFound();
            }

            return View(disrepair);
        }

        // GET: Disrepairs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disrepairs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FailureCd,FailureName")] Disrepair disrepair)
        {
            if (ModelState.IsValid)
            {
                if (DisrepairAllRight(disrepair))
                {
                    _context.Add(disrepair);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            return View(disrepair);
        }

        // GET: Disrepairs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disrepair = await _context.Disrepairs.FindAsync(id);
            if (disrepair == null)
            {
                return NotFound();
            }
            return View(disrepair);
        }

        // POST: Disrepairs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FailureCd,FailureName")] Disrepair disrepair)
        {
            if (id != disrepair.FailureCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (DisrepairAllRight(disrepair))
                    {
                        _context.Update(disrepair);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisrepairExists(disrepair.FailureCd))
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
            return View(disrepair);
        }

        // GET: Disrepairs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disrepair = await _context.Disrepairs
                .FirstOrDefaultAsync(m => m.FailureCd == id);
            if (disrepair == null)
            {
                return NotFound();
            }

            return View(disrepair);
        }

        // POST: Disrepairs/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disrepair = await _context.Disrepairs.FindAsync(id);
            if (!_context.Requests.Any(x => x.FailureCd == id))
            {
                _context.Disrepairs.Remove(disrepair);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DisrepairExists(int id)
        {
            return _context.Disrepairs.Any(e => e.FailureCd == id);
        }

        private bool DisrepairAllRight(Disrepair _disrepair)
        {
            bool FailureNameAllRight;
            if (_disrepair.FailureName != null)
                FailureNameAllRight = Regex.IsMatch(_disrepair.FailureName, @"^[^a-zA-Z0-9]+$");
            else
                FailureNameAllRight = false;

            bool Result = FailureNameAllRight;
            return Result;
        }
    }
}
