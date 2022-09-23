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
    public class RequestsController : Controller
    {
        private readonly BillingDbContext _context;

        public RequestsController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: Requests
        public async Task<IActionResult> Index()
        {
            var billingDbContext = _context.Requests.Include(r => r.AccountCdNavigation).Include(r => r.ExecutorCdNavigation).Include(r => r.FailureCdNavigation);
            return View(await billingDbContext.ToListAsync());
        }

        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.AccountCdNavigation)
                .Include(r => r.ExecutorCdNavigation)
                .Include(r => r.FailureCdNavigation)
                .FirstOrDefaultAsync(m => m.RequestCd == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Requests/Create
        public IActionResult Create()
        {
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd");
            ViewData["ExecutorCd"] = new SelectList(_context.Executors, "ExecutorCd", "Fio");
            ViewData["FailureCd"] = new SelectList(_context.Disrepairs, "FailureCd", "FailureName");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequestCd,AccountCd,FailureCd,ExecutorCd,IncomingDate,ExecutionDate,Executed")] Request request)
        {
            if (ModelState.IsValid)
            {
                if (RequestAllRight(request))
                {
                    _context.Add(request);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd", request.AccountCd);
            ViewData["ExecutorCd"] = new SelectList(_context.Executors, "ExecutorCd", "Fio", request.ExecutorCd);
            ViewData["FailureCd"] = new SelectList(_context.Disrepairs, "FailureCd", "FailureName", request.FailureCd);
            return View(request);
        }

        // GET: Requests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd", request.AccountCd);
            ViewData["ExecutorCd"] = new SelectList(_context.Executors, "ExecutorCd", "Fio", request.ExecutorCd);
            ViewData["FailureCd"] = new SelectList(_context.Disrepairs, "FailureCd", "FailureName", request.FailureCd);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequestCd,AccountCd,FailureCd,ExecutorCd,IncomingDate,ExecutionDate,Executed")] Request request)
        {
            if (id != request.RequestCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (RequestAllRight(request))
                    {
                        _context.Update(request);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.RequestCd))
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
            ViewData["AccountCd"] = new SelectList(_context.Abonents, "AccountCd", "AccountCd", request.AccountCd);
            ViewData["ExecutorCd"] = new SelectList(_context.Executors, "ExecutorCd", "Fio", request.ExecutorCd);
            ViewData["FailureCd"] = new SelectList(_context.Disrepairs, "FailureCd", "FailureName", request.FailureCd);
            return View(request);
        }

        // GET: Requests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .Include(r => r.AccountCdNavigation)
                .Include(r => r.ExecutorCdNavigation)
                .Include(r => r.FailureCdNavigation)
                .FirstOrDefaultAsync(m => m.RequestCd == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.RequestCd == id);
        }

        private bool RequestAllRight(Request _request)
        {
            bool IncomingDateAllRight;
            if (_request.IncomingDate <= DateTime.Now)
                IncomingDateAllRight = true;
            else
                IncomingDateAllRight = false;

            bool ExecutionDateAllRight;
            if (_request.ExecutionDate >= _request.IncomingDate)
                ExecutionDateAllRight = true;
            else
                ExecutionDateAllRight = false;

            bool Result = IncomingDateAllRight && ExecutionDateAllRight;
            return Result;
        }

    }
}
