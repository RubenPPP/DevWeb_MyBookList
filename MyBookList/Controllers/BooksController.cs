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
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var myBookListContext = _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.AuthorsList)
                .Include(b => b.GenresList);
            return View(await myBookListContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.AuthorsList)
                .Include(b => b.GenresList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["GenresList"] = new SelectList(_context.Genres, "Id", "Genre");
            ViewData["PublisherFK"] = new SelectList(_context.Publishers, "Id", "Name");
            ViewData["AuthorsList"] = new SelectList(_context.Authors, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ISBN,Title,Description,GenresList,AuthorsList,PublisherFK")] Books books, int[] GenresList, int[] AuthorsList)
        {
            if (ModelState.IsValid)
            {
                // Set the selected genres, authors and publisher for the book
                books.GenresList = await _context.Genres.Where(g => GenresList.Contains(g.Id)).ToListAsync();
                books.AuthorsList = await _context.Authors.Where(a => AuthorsList.Contains(a.Id)).ToListAsync();
                books.Publisher = await _context.Publishers.FindAsync(books.PublisherFK);
                // Nulls the status list as it's a new book
                books.StatusList = null;

                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenresList"] = new SelectList(_context.Genres, "Id", "Genre");
            ViewData["AuthorsList"] = new SelectList(_context.Authors, "Id", "Name", books.AuthorsList);
            ViewData["PublisherFK"] = new SelectList(_context.Publishers, "Id", "Name", books.PublisherFK);
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FindAsync(id);
            if (books == null)
            {
                return NotFound();
            }
            ViewData["GenresList"] = new SelectList(_context.Genres, "Id", "Genre");
            ViewData["AuthorsList"] = new SelectList(_context.Authors, "Id", "Name", books.AuthorsList);
            ViewData["PublisherFK"] = new SelectList(_context.Publishers, "Id", "Name", books.PublisherFK);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ISBN,Title,Description,GenresList,AuthorsList,PublisherFK")] Books books, int[] GenresList, int[] AuthorsList)
        {
            if (id != books.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Set the selected genres, authors and publisher for the book
                    books.GenresList = await _context.Genres.Where(g => GenresList.Contains(g.Id)).ToListAsync();
                    books.AuthorsList = await _context.Authors.Where(a => AuthorsList.Contains(a.Id)).ToListAsync();
                    books.Publisher = await _context.Publishers.FindAsync(books.PublisherFK);

                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.Id))
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
            ViewData["PublisherFK"] = new SelectList(_context.Publishers, "Id", "Name", books.PublisherFK);
            ViewData["AuthorsList"] = new SelectList(_context.Authors, "Id", "Name", books.AuthorsList);
            ViewData["PublisherFK"] = new SelectList(_context.Publishers, "Id", "Name", books.PublisherFK);
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.AuthorsList)
                .Include(b => b.GenresList)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'MyBookListContext.Books'  is null.");
            }
            var books = await _context.Books.FindAsync(id);
            if (books != null)
            {
                _context.Books.Remove(books);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooksExists(int id)
        {
            return (_context.Books?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}