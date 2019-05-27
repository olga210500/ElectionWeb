using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElectionWeb;

namespace ElectionWeb.Controllers
{
    public class ControlCouponsController : Controller
    {
        private readonly electionContext _context;

        public ControlCouponsController(electionContext context)
        {
            _context = context;
        }

        // GET: ControlCoupons
        public async Task<IActionResult> Index()
        {
            var electionContext = _context.ControlCoupon.Include(c => c.City).Include(c => c.Election).Include(c => c.Voter);
            return View(await electionContext.ToListAsync());
        }

        // GET: ControlCoupons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlCoupon = await _context.ControlCoupon
                .Include(c => c.City)
                .Include(c => c.Election)
                .Include(c => c.Voter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlCoupon == null)
            {
                return NotFound();
            }

            return View(controlCoupon);
        }

        // GET: ControlCoupons/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.City, "Id", "City1");
            ViewData["ElectionId"] = new SelectList(_context.Election, "Id", "Id");
            ViewData["VoterId"] = new SelectList(_context.Voter, "Id", "Id");
            return View();
        }

        // POST: ControlCoupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ElectionId,CityId,VoterId")] ControlCoupon controlCoupon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(controlCoupon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "City1", controlCoupon.CityId);
            ViewData["ElectionId"] = new SelectList(_context.Election, "Id", "Id", controlCoupon.ElectionId);
            ViewData["VoterId"] = new SelectList(_context.Voter, "Id", "Id", controlCoupon.VoterId);
            return View(controlCoupon);
        }

        // GET: ControlCoupons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlCoupon = await _context.ControlCoupon.FindAsync(id);
            if (controlCoupon == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "Id", "City1", controlCoupon.CityId);
            ViewData["ElectionId"] = new SelectList(_context.Election, "Id", "Id", controlCoupon.ElectionId);
            ViewData["VoterId"] = new SelectList(_context.Voter, "Id", "Id", controlCoupon.VoterId);
            return View(controlCoupon);
        }

        // POST: ControlCoupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ElectionId,CityId,VoterId")] ControlCoupon controlCoupon)
        {
            if (id != controlCoupon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(controlCoupon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ControlCouponExists(controlCoupon.Id))
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
            ViewData["CityId"] = new SelectList(_context.City, "Id", "City1", controlCoupon.CityId);
            ViewData["ElectionId"] = new SelectList(_context.Election, "Id", "Id", controlCoupon.ElectionId);
            ViewData["VoterId"] = new SelectList(_context.Voter, "Id", "Id", controlCoupon.VoterId);
            return View(controlCoupon);
        }

        // GET: ControlCoupons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlCoupon = await _context.ControlCoupon
                .Include(c => c.City)
                .Include(c => c.Election)
                .Include(c => c.Voter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (controlCoupon == null)
            {
                return NotFound();
            }

            return View(controlCoupon);
        }

        // POST: ControlCoupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var controlCoupon = await _context.ControlCoupon.FindAsync(id);
            _context.ControlCoupon.Remove(controlCoupon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ControlCouponExists(int id)
        {
            return _context.ControlCoupon.Any(e => e.Id == id);
        }
    }
}
