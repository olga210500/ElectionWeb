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
    public class BulletinsController : Controller
    {
        private readonly electionContext _context;

        public BulletinsController(electionContext context)
        {
            _context = context;
        }

        // GET: Bulletins
        public async Task<IActionResult> Index()
        {
            var electionContext = _context.Bulletin.Include(b => b.Candidate).Include(b => b.City).Include(b => b.Election);
            return View(await electionContext.ToListAsync());
        }

        // GET: Bulletins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bulletin = await _context.Bulletin
                .Include(b => b.Candidate)
                .Include(b => b.City)
                .Include(b => b.Election)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bulletin == null)
            {
                return NotFound();
            }

            return View(bulletin);
        }

        // GET: Bulletins/Create
        public IActionResult Create()
        {
            ViewData["CandidateId"] = new SelectList(_context.Candidate, "Id", "PreelectionProgram");
            ViewData["CityId"] = new SelectList(_context.City, "Id", "City1");
            ViewData["ElectionId"] = new SelectList(_context.Election, "Id", "Id");
            return View();
        }

        // POST: Bulletins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ElectionId,CityId,CandidateId")] Bulletin bulletin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bulletin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidate, "Id", "PreelectionProgram", bulletin.CandidateId);
            ViewData["CityId"] = new SelectList(_context.City, "Id", "City1", bulletin.CityId);
            ViewData["ElectionId"] = new SelectList(_context.Election, "Id", "Id", bulletin.ElectionId);
            return View(bulletin);
        }

        // GET: Bulletins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bulletin = await _context.Bulletin.FindAsync(id);
            if (bulletin == null)
            {
                return NotFound();
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidate, "Id", "PreelectionProgram", bulletin.CandidateId);
            ViewData["CityId"] = new SelectList(_context.City, "Id", "City1", bulletin.CityId);
            ViewData["ElectionId"] = new SelectList(_context.Election, "Id", "Id", bulletin.ElectionId);
            return View(bulletin);
        }

        // POST: Bulletins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ElectionId,CityId,CandidateId")] Bulletin bulletin)
        {
            if (id != bulletin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bulletin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BulletinExists(bulletin.Id))
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
            ViewData["CandidateId"] = new SelectList(_context.Candidate, "Id", "PreelectionProgram", bulletin.CandidateId);
            ViewData["CityId"] = new SelectList(_context.City, "Id", "City1", bulletin.CityId);
            ViewData["ElectionId"] = new SelectList(_context.Election, "Id", "Id", bulletin.ElectionId);
            return View(bulletin);
        }

        // GET: Bulletins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bulletin = await _context.Bulletin
                .Include(b => b.Candidate)
                .Include(b => b.City)
                .Include(b => b.Election)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bulletin == null)
            {
                return NotFound();
            }

            return View(bulletin);
        }

        // POST: Bulletins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bulletin = await _context.Bulletin.FindAsync(id);
            _context.Bulletin.Remove(bulletin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BulletinExists(int id)
        {
            return _context.Bulletin.Any(e => e.Id == id);
        }
    }
}
