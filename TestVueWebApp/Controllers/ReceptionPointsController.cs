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
    public class ReceptionPointsController : Controller
    {
        private readonly BillingDbContext _context;

        public ReceptionPointsController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: ReceptionPoints
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReceptionPoints.ToListAsync());
        }

        // GET: ReceptionPoints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptionPoint = await _context.ReceptionPoints
                .FirstOrDefaultAsync(m => m.ReceptionPointCd == id);
            if (receptionPoint == null)
            {
                return NotFound();
            }

            return View(receptionPoint);
        }

        // GET: ReceptionPoints/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReceptionPoints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReceptionPointCd,ReceptionName")] ReceptionPoint receptionPoint)
        {
            if (ModelState.IsValid)
            {
                if (ReceptionPointAllRight(receptionPoint))
                {
                    _context.Add(receptionPoint);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            return View(receptionPoint);
        }

        // GET: ReceptionPoints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptionPoint = await _context.ReceptionPoints.FindAsync(id);
            if (receptionPoint == null)
            {
                return NotFound();
            }
            return View(receptionPoint);
        }

        // POST: ReceptionPoints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReceptionPointCd,ReceptionName")] ReceptionPoint receptionPoint)
        {
            if (id != receptionPoint.ReceptionPointCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ReceptionPointAllRight(receptionPoint))
                    {
                        _context.Update(receptionPoint);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceptionPointExists(receptionPoint.ReceptionPointCd))
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
            return View(receptionPoint);
        }

        // GET: ReceptionPoints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptionPoint = await _context.ReceptionPoints
                .FirstOrDefaultAsync(m => m.ReceptionPointCd == id);
            if (receptionPoint == null)
            {
                return NotFound();
            }

            return View(receptionPoint);
        }

        // POST: ReceptionPoints/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receptionPoint = await _context.ReceptionPoints.FindAsync(id);
            if (!_context.PaySummas.Any(x => x.ReceptionPointCd == id))
            {
                _context.ReceptionPoints.Remove(receptionPoint);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReceptionPointExists(int id)
        {
            return _context.ReceptionPoints.Any(e => e.ReceptionPointCd == id);
        }

        private bool ReceptionPointAllRight(ReceptionPoint _receptionPoint)
        {
            bool ReceptionNameAllRight;
            if (_receptionPoint.ReceptionName != null)
                ReceptionNameAllRight = Regex.IsMatch(_receptionPoint.ReceptionName, @"^[^a-zA-Z0-9]+$");
            else
                ReceptionNameAllRight = false;

            bool Result = ReceptionNameAllRight;
            return Result;
        }

    }
}
