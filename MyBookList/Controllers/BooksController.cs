using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBookList.Data;
using MyBookList.Models;
using NuGet.Packaging;
using NuGet.Protocol;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.AspNetCore.Authorization;

namespace MyBookList.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Books
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var myBookListContext = _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.AuthorsList)
                .Include(b => b.GenresList);
            return View(await myBookListContext.ToListAsync());
        }

        // GET: Books/Details/5
        [AllowAnonymous]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,ISBN,Title,Description,GenresList,AuthorsList,PublisherFK")] Books book, int[] GenresList, int[] AuthorsList)
        {
            if (ModelState.IsValid)
            {
                // Set the selected genres, authors and publisher for the book
                book.GenresList = await _context.Genres.Where(g => GenresList.Contains(g.Id)).ToListAsync();
                book.AuthorsList = await _context.Authors.Where(a => AuthorsList.Contains(a.Id)).ToListAsync();
                if (book.PublisherFK != 0)
                    book.Publisher = await _context.Publishers.FindAsync(book.PublisherFK);
                else
                {
                    book.Publisher = null;
                    book.PublisherFK = null;
                }
                // Nulls the status list as it's a new book
                book.StatusList = null;

                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenresList"] = new SelectList(_context.Genres, "Id", "Genre");
            ViewData["AuthorsList"] = new SelectList(_context.Authors, "Id", "Name", book.AuthorsList);
            ViewData["PublisherFK"] = new SelectList(_context.Publishers, "Id", "Name", book.PublisherFK);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ISBN,Title,Description,PublisherFK")] Books book, int[] GenresList, int[] AuthorsList)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            // SOURCE : https://github.com/jcnpereira/bd-Muitos-Para-Muitos-ASP.NetCore/
            // Nota : Obrigado.
            //
            //  GÉNERO
            //
            // Dados dos Géneros anteriormente guardados
            var existingBook = await _context.Books
                                       .Where(b => b.Id == id)
                                       .Include(b => b.GenresList)
                                       .FirstOrDefaultAsync();

            // Obter a lista dos IDs dos géneros associadas aos livros, antes da edição
            var oldGenresList = existingBook.GenresList
                                           .Select(g => g.Id)
                                           .ToList();

            // Avaliar se o utilizador alterou alguma Category associada à Lesson
            // adicionadas -> lista de categorias adicionadas
            // retiradas   -> lista de categorias retiradas
            var adicionadas = GenresList.Except(oldGenresList);
            var retiradas = oldGenresList.Except(GenresList.ToList());

            // Se alguma Category foi adicionada ou retirada
            // é necessário alterar a lista de categorias 
            // Associada ao género
            if (adicionadas.Any() || retiradas.Any())
            {

                if (retiradas.Any())
                {
                    // retirar a Category 
                    foreach (int oldGenre in retiradas)
                    {
                        var genreToRemove = existingBook.GenresList.FirstOrDefault(g => g.Id == oldGenre);
                        existingBook.GenresList.Remove(genreToRemove);
                    }
                }
                if (adicionadas.Any())
                {
                    // adicionar a Category 
                    foreach (int newGenre in adicionadas)
                    {
                        var genreToAdd = await _context.Genres.FirstOrDefaultAsync(g => g.Id == newGenre);
                        existingBook.GenresList.Add(genreToAdd);
                    }
                }
            }

            //  AUTOR
            // Dados dos Géneros anteriormente guardados
            existingBook = await _context.Books
                                       .Where(b => b.Id == id)
                                       .Include(b => b.AuthorsList)
                                       .FirstOrDefaultAsync();

            // Obter a lista dos IDs dos géneros associadas aos livros, antes da edição
            var oldAuthorsList = existingBook.AuthorsList
                                           .Select(a => a.Id)
                                           .ToList();

            // Avaliar se o utilizador alterou alguma Category associada à Lesson
            // adicionadas -> lista de categorias adicionadas
            // retiradas   -> lista de categorias retiradas
            adicionadas = AuthorsList.Except(oldAuthorsList);
            retiradas = oldAuthorsList.Except(AuthorsList.ToList());

            // Se alguma Category foi adicionada ou retirada
            // é necessário alterar a lista de categorias 
            // Associada ao género
            if (adicionadas.Any() || retiradas.Any())
            {

                if (retiradas.Any())
                { 
                    foreach (int oldAuthor in retiradas)
                    {
                        var authorToRemove = existingBook.AuthorsList.FirstOrDefault(a => a.Id == oldAuthor);
                        existingBook.AuthorsList.Remove(authorToRemove);
                    }
                }
                if (adicionadas.Any())
                {
                    foreach (int newAuthor in adicionadas)
                    {
                        var authorToAdd = await _context.Authors.FirstOrDefaultAsync(a => a.Id == newAuthor);
                        existingBook.AuthorsList.Add(authorToAdd);
                    }
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (book.PublisherFK != 0)
                        existingBook.Publisher = await _context.Publishers.FindAsync(book.PublisherFK);
                    else
                    {
                        existingBook.Publisher = null;
                        existingBook.PublisherFK = null;
                    }
                    if (AuthorsList.Contains(0))
                        existingBook.AuthorsList = null;
                    if (GenresList.Contains(0))
                        existingBook.GenresList = null;
                    _context.Update(existingBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(book.Id))
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
            ViewData["GenresList"] = GenresList;
            ViewData["AuthorsList"] = AuthorsList;
            ViewData["PublisherFK"] = new SelectList(_context.Publishers, "Id", "Name", book.PublisherFK);
            return View(book);
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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