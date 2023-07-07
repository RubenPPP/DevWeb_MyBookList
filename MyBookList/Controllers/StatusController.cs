using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBookList.Data;
using MyBookList.Models;

namespace MyBookList.Controllers
{
    public class StatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Status.Include(s => s.Book).Include(s => s.Member);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .Include(s => s.Book)
                .Include(s => s.Member)
                .FirstOrDefaultAsync(m => m.MemberFK == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            ViewData["BookFK"] = new SelectList(_context.Books, "Id", "ISBN");
            ViewData["MemberFK"] = new SelectList(_context.Members, "Id", "Status");
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberFK,BookFK,State,ScoreRating,Review,ReviewDate")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookFK"] = new SelectList(_context.Books, "Id", "ISBN", status.BookFK);
            ViewData["MemberFK"] = new SelectList(_context.Members, "Id", "Status", status.MemberFK);
            return View(status);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            ViewData["BookFK"] = new SelectList(_context.Books, "Id", "ISBN", status.BookFK);
            ViewData["MemberFK"] = new SelectList(_context.Members, "Id", "Status", status.MemberFK);
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberFK,BookFK,State,ScoreRating,Review,ReviewDate")] Status status)
        {
            if (id != status.MemberFK)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.MemberFK))
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
            ViewData["BookFK"] = new SelectList(_context.Books, "Id", "ISBN", status.BookFK);
            ViewData["MemberFK"] = new SelectList(_context.Members, "Id", "Status", status.MemberFK);
            return View(status);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Status == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .Include(s => s.Book)
                .Include(s => s.Member)
                .FirstOrDefaultAsync(m => m.MemberFK == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Status == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Status'  is null.");
            }
            var status = await _context.Status.FindAsync(id);
            if (status != null)
            {
                _context.Status.Remove(status);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(int id)
        {
          return (_context.Status?.Any(e => e.MemberFK == id)).GetValueOrDefault();
        }
    }
}
