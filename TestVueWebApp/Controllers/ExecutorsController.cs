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
    public class ExecutorsController : Controller
    {
        private readonly BillingDbContext _context;

        public ExecutorsController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: Executors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Executors.ToListAsync());
        }

        // GET: Executors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var executor = await _context.Executors
                .FirstOrDefaultAsync(m => m.ExecutorCd == id);
            if (executor == null)
            {
                return NotFound();
            }

            return View(executor);
        }

        // GET: Executors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Executors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExecutorCd,Fio")] Executor executor)
        {
            if (ModelState.IsValid)
            {
                if (ExecutorAllRight(executor))
                {
                    _context.Add(executor);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            return View(executor);
        }

        // GET: Executors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var executor = await _context.Executors.FindAsync(id);
            if (executor == null)
            {
                return NotFound();
            }
            return View(executor);
        }

        // POST: Executors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExecutorCd,Fio")] Executor executor)
        {
            if (id != executor.ExecutorCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ExecutorAllRight(executor))
                    {
                        _context.Update(executor);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExecutorExists(executor.ExecutorCd))
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
            return View(executor);
        }

        // GET: Executors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var executor = await _context.Executors
                .FirstOrDefaultAsync(m => m.ExecutorCd == id);
            if (executor == null)
            {
                return NotFound();
            }

            return View(executor);
        }

        // POST: Executors/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var executor = await _context.Executors.FindAsync(id);
            if (!_context.Requests.Any(x => x.ExecutorCd == id))
            {
                _context.Executors.Remove(executor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ExecutorExists(int id)
        {
            return _context.Executors.Any(e => e.ExecutorCd == id);
        }

        private bool ExecutorAllRight(Executor _executor)
        {
            bool FioAllRight;
            if (_executor.Fio != null)
                FioAllRight = Regex.IsMatch(_executor.Fio, @"^[^a-zA-Z0-9]+$");
            else
                FioAllRight = false;

            bool Result = FioAllRight;
            return Result;
        }
    }
}
