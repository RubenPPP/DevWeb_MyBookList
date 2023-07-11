using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBookList.Data;
using MyBookList.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MyBookList.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public StatusController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var member = await _context.Members
            .Include(m => m.StatusList)
            .FirstOrDefaultAsync(m => m.UserId == userId);

            if (member != null)
            {
                var statuses = await _context.Status
                .Include(s => s.Book)
                .Where(s => s.MemberFK == member.Id)
                .ToListAsync();

                return View(statuses);
            }

            return Problem("Member não encontrado.");
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
        public async Task<IActionResult> Create(int bookId, int selectedStatus, string critica)
        {
            var book = await _context.Books.FindAsync(bookId);
            var user = await _userManager.GetUserAsync(User); // Retrieve the currently logged-in user

            if (book != null && user != null)
            {
                var member = await _context.Members.FirstOrDefaultAsync(m => m.UserId == user.Id);

                var status = new Status
                {
                    BookFK = book.Id,
                    Book = book,
                    MemberFK = member.Id,
                    Member = member,
                    State = selectedStatus == 0 ? "A Ler" : selectedStatus == 1 ? "Leu" : selectedStatus == 2 ? "Planeia Ler" : "Desistiu",
                    Review = critica,
                    ReviewDate = DateTime.Now.ToString(),
                };

                book.StatusList.Add(status);
                member.StatusList.Add(status);

                _context.Status.Add(status);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(BooksController.Details), "Books", new { id = bookId });
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
