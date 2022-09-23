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
    public class ServicesController : Controller
    {
        private readonly BillingDbContext _context;

        public ServicesController(BillingDbContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var billingDbContext = _context.Services.Include(s => s.UnitsCdNavigation);
            return View(await billingDbContext.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.UnitsCdNavigation)
                .FirstOrDefaultAsync(m => m.ServiceCd == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["UnitsCd"] = new SelectList(_context.Units, "UnitCd", "UnitsName");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceCd,ServiceName,UnitsCd")] Service service)
        {
            if (ModelState.IsValid)
            {
                if (ServiceAllRight(service))
                {
                    _context.Add(service);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            ViewData["UnitsCd"] = new SelectList(_context.Units, "UnitCd", "UnitsName", service.UnitsCd);
            return View(service);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["UnitsCd"] = new SelectList(_context.Units, "UnitCd", "UnitsName", service.UnitsCd);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceCd,ServiceName,UnitsCd")] Service service)
        {
            if (id != service.ServiceCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ServiceAllRight(service))
                    {
                        _context.Update(service);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.ServiceCd))
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
            ViewData["UnitsCd"] = new SelectList(_context.Units, "UnitCd", "UnitsName", service.UnitsCd);
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .Include(s => s.UnitsCdNavigation)
                .FirstOrDefaultAsync(m => m.ServiceCd == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (!_context.Modes.Any(x => x.ServiceCd == id) && !_context.Remains.Any(x => x.ServiceCd == id))
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.ServiceCd == id);
        }

        private bool ServiceAllRight(Service _service)
        {
            bool ServiceNameNameAllRight;
            if (_service.ServiceName != null)
                ServiceNameNameAllRight = Regex.IsMatch(_service.ServiceName, @"^[^a-zA-Z0-9]+$");
            else
                ServiceNameNameAllRight = false;

            bool Result = ServiceNameNameAllRight;
            return Result;
        }

    }
}
