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
    public class AbonentsController : Controller
    {
        private readonly BillingDbContext _context;

        public AbonentsController(BillingDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var billingDbContext = _context.Abonents.Include(a => a.StreetCdNavigation);
            return View(await billingDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonent = await _context.Abonents
                .Include(a => a.StreetCdNavigation)
                .FirstOrDefaultAsync(m => m.AccountCd == id);
            if (abonent == null)
            {
                return NotFound();
            }

            return View(abonent);
        }

        public IActionResult Create()
        {
            ViewData["StreetCd"] = new SelectList(_context.Streets, "StreetCd", "StreetName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("AccountCd,Fio,StreetCd,HouseNo,FlatNo,Phone,Сorpus,District,CountPerson,SizeFlat")] Abonent abonent)
        {
            if (ModelState.IsValid)
            {
                if (AbonentAllRight(abonent))
                {
                    _context.Add(abonent);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                    return RedirectToAction(nameof(Create));
            }
            ViewData["StreetCd"] = new SelectList(_context.Streets, "StreetCd", "StreetName", abonent.StreetCd);
            return View(abonent);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonent = await _context.Abonents.FindAsync(id);
            if (abonent == null)
            {
                return NotFound();
            }
            ViewData["StreetCd"] = new SelectList(_context.Streets, "StreetCd", "StreetName", abonent.StreetCd);
            return View(abonent);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("AccountCd,Fio,StreetCd,HouseNo,FlatNo,Phone,Сorpus,District,CountPerson,SizeFlat")] Abonent abonent)
        {
            if (id != abonent.AccountCd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (AbonentAllRight(abonent))
                    {
                        _context.Update(abonent);
                        await _context.SaveChangesAsync();
                    }
                    else
                        return RedirectToAction(nameof(Edit));

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AbonentExists(abonent.AccountCd))
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
            ViewData["StreetCd"] = new SelectList(_context.Streets, "StreetCd", "StreetName", abonent.StreetCd);
            return View(abonent);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var abonent = await _context.Abonents
                .Include(a => a.StreetCdNavigation)
                .FirstOrDefaultAsync(m => m.AccountCd == id);
            if (abonent == null)
            {
                return NotFound();
            }

            return View(abonent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var abonent = await _context.Abonents.FindAsync(id);
            if (!_context.Requests.Any(x => x.AccountCd == id) && !_context.Remains.Any(x => x.AccountCd == id) && !_context.AbonentModes.Any(x => x.AccountCd == id))
            {
                _context.Abonents.Remove(abonent);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool AbonentExists(string id)
        {
            return _context.Abonents.Any(e => e.AccountCd == id);
        }

        private bool AbonentAllRight(Abonent _abonent)
        {
            bool accountCdAllRight;
            if (_abonent.AccountCd != null)
                accountCdAllRight = Regex.IsMatch(_abonent.AccountCd.ToString(), @"^\d{6}$");
            else
                accountCdAllRight = false;

            bool fioAllRight;
            if (_abonent.Fio != null)
                fioAllRight = Regex.IsMatch(_abonent.Fio, @"^[^a-zA-Z0-9]+$");
            else
                fioAllRight = false;

            bool HouseNoAllRight;
            if (_abonent.HouseNo != 0)
                HouseNoAllRight = Regex.IsMatch(_abonent.HouseNo.ToString(), @"^\d+$");
            else
                HouseNoAllRight = false;

            bool DistrictAllRight;
            if (_abonent.District != null)
                DistrictAllRight = Regex.IsMatch(_abonent.District, @"^[^a-zA-Z0-9]+$");
            else
                DistrictAllRight = true;

            bool FlatNoAllRight;
            if (_abonent.FlatNo != null)
                FlatNoAllRight = Regex.IsMatch(_abonent.FlatNo.ToString(), @"^\d+$");
            else
                FlatNoAllRight = true;

            bool СorpusAllRight;
            if (_abonent.Сorpus != null)
                СorpusAllRight = Regex.IsMatch(_abonent.Сorpus.ToString(), @"^\d+$");
            else
                СorpusAllRight = true;

            bool CountPersonAllRight;
            if (_abonent.CountPerson != null)
                CountPersonAllRight = Regex.IsMatch(_abonent.CountPerson.ToString(), @"^\d+$");
            else
                CountPersonAllRight = true;

            bool SizeFlatAllRight;
            if (_abonent.SizeFlat != null)
                SizeFlatAllRight = Regex.IsMatch(_abonent.SizeFlat.ToString(), @"^\d+,?\d+$");
            else
                SizeFlatAllRight = true;

            bool PhoneAllRight;
            if (_abonent.Phone != null)
            {
                PhoneAllRight = Regex.IsMatch(_abonent.Phone.ToString(), @"^8\(\d{3}\)-\d{3}-\d{2}-\d{2}$");
            }
            else
                PhoneAllRight = true;
            bool Result = accountCdAllRight && fioAllRight && DistrictAllRight && FlatNoAllRight && HouseNoAllRight && СorpusAllRight && CountPersonAllRight && SizeFlatAllRight && PhoneAllRight;
            return Result;
        }
    }
}
