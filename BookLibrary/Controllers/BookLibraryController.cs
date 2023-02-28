using BookLibrary.Data;
using BookLibrary.Dto;
using BookLibrary.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly BookLibraryContext _context;

        public BookController(BookLibraryContext context)
        {
            _context = context;

        }
        [HttpGet()]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _context.Books.Include(b => b.Authors).Include(b => b.Genres).ToListAsync();
            if (books == null)
            {
                return NotFound($"Book not found");
            }
            

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book  = await _context.Books.Where(b => b.BookId == id).Include(b=> b.Authors).Include(b=> b.Genres).FirstOrDefaultAsync(); 
            if(book == null)
            {
                return NotFound($"Book not found");
            }
            var bookResponse = BookResponse.FromBook(book);

            return Ok(book
);
        }

        [HttpGet("top/authors")]
        public async Task<IActionResult> GetTopAuthors()
        {
            var top_authors = _context.Books.OrderByDescending(t => t.Authors.Count).Take(5);
            if (top_authors == null)
            {
                return NotFound($"Book not found");
            }

       
            return Ok(top_authors);
        }

        [HttpGet("top/genres")]
        public async Task<IActionResult> GetTopGenres()
        {
            var top_genres =  _context.Books.OrderByDescending(t => t.Genres.Count).Take(5); ;
            if (top_genres == null)
            {
                return NotFound($"Book not foundddd");
            }
           

            return Ok(top_genres);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookRequest bookRequest)
        {
         
            var book = Book.Map(bookRequest);
            if(bookRequest.Authors is not null)
            {
                
                book.Authors = bookRequest.Authors;
                
            }

            if (bookRequest.Genres is not null)
            {
          
                book.Genres = bookRequest.Genres;
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new {id = book.BookId}, BookResponse.FromBook(book));
              
            //return Ok(await _context.SaveChangesAsync());

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookRequest bookRequest)
        {
            var updatedBook = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if(updatedBook == null)
            {
                return NotFound();
            }

            updatedBook.ReplaceWithBookRequest(bookRequest);
            _context.Update(updatedBook);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var deletedBook = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);    
            if(deletedBook == null)
            {
                return NotFound();
            }
            _context.Books.Remove(deletedBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
