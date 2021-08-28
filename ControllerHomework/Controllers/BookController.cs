using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllerHomework.Models;

namespace ControllerHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BooksDbContext _context;

        public BookController(BooksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _context.Books.Where(b => b.Id == id).Select(i => new { i.Id, i.Name, i.Genre, i.Authors }).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult RemoveBook(int id)
        {
            var book = _context.Books.Where(b => b.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("{id}/{newName}")]
        public IActionResult UpdateBookName(int id, string newName)
        {
            var book = _context.Books.Where(b => b.Id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            book.Name = newName;

            _context.SaveChanges();

            return Ok(book);
        }
    }
}
