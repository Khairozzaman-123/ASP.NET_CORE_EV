using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eBooks.Models;
using eBooks.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace eBooks.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;
        private readonly IHostingEnvironment _he;

   
        public BooksController(BookDbContext context, IHostingEnvironment he)
        {
            _context = context;
            this._he = he;
        }
        [AllowAnonymous]
        // GET: Books
        public async Task<IActionResult> Index()
        {
            var bookDbContext = _context.Books.Include(b => b.Publisher);
            return View(await bookDbContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel bvm)
        {
            if (ModelState.IsValid)
            {
                Book b = new Book();
                b.BookName = bvm.BookName;
                b.PublishDate = bvm.PublishDate;
                b.PublisherId = bvm.PublisherId;
                b.Price = bvm.Price;

                string webroot = _he.WebRootPath;
                string folder = "Images";
                string imageFileName =Path.GetFileName(bvm.Picture.FileName);
                string fileToWrite = Path.Combine(webroot, folder, imageFileName);
                b.CoverImage = imageFileName;

                //using (MemoryStream ms=new MemoryStream())
                //{
                //    await bvm.Picture.CopyToAsync(ms);
                //    b.CoverImage = imageFileName;
                //}

                using (var stream=new FileStream(fileToWrite, FileMode.Create))
                {
                    await bvm.Picture.CopyToAsync(stream);
                }

                _context.Add(b);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName", bvm.PublisherId);
            return View(bvm);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            BookViewModel bvm = new BookViewModel()
            {
                BookId = book.BookId,
                BookName = book.BookName,
                PublishDate = book.PublishDate,
                PublisherId = book.PublisherId,
                Price = book.Price,
                CoverImage = book.CoverImage
            };
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName", bvm.PublisherId);
            return View(bvm);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(/*int id, [Bind("BookId,BookName,PublisherId,PublishDate,Price,CoverImage")] */BookViewModel bvm)
        {
            //if (id != bvm.BookId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    string webroot = _he.WebRootPath;
                    string folder = "Images";
                    string imageFileName = Path.GetFileName(bvm.Picture.FileName);
                    string fileToWrite = Path.Combine(webroot, folder, imageFileName);

                    Book b = new Book()
                    {
                        BookId=bvm.BookId,
                        BookName = bvm.BookName,
                        PublishDate = bvm.PublishDate,
                        PublisherId = bvm.PublisherId,
                        Price = bvm.Price,
                        CoverImage=imageFileName
                    };

                    using (var stream = new FileStream(fileToWrite, FileMode.Create))
                    {
                        await bvm.Picture.CopyToAsync(stream);
                    }

                    _context.Update(b);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(bvm.BookId))
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
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName", bvm.PublisherId);
            return View(bvm);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
