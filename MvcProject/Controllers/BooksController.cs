using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcProject.Models;
using MvcProject.Models.Entities;

namespace MvcProject.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationContext _applicationContext;
        public BooksController(ApplicationContext context)
        {
            _applicationContext = context;

            ///seed test data////
            if (!_applicationContext.Books.Any())
            {

                _applicationContext.Books.Add(new Book { Name = "Book1", Author = "Autrhor1", Year = 2000 });
                _applicationContext.Books.Add(new Book { Name = "Book2", Author = "Autrhor2", Year = 2001 });
                _applicationContext.SaveChanges();
            }
            //////
        }

        public IActionResult Index() => View(_applicationContext.Books.ToList());
        public IActionResult Create() => View();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            return await _applicationContext.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBook(int id)
        {
            Book book = await _applicationContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _applicationContext.Books.Add(book);
            await _applicationContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Books");
        }
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book book = _applicationContext.Books.Find(id);
            if (book != null)
            {
                return View(book);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<ActionResult<Book>> EditBook(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!_applicationContext.Books.Any(x => x.Id == book.Id))
            {
                return NotFound();
            }
            _applicationContext.Update(book);
            await _applicationContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Books");
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            Book book = _applicationContext.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _applicationContext.Remove(book);
            await _applicationContext.SaveChangesAsync();
            return Ok();
        }
    }
}
