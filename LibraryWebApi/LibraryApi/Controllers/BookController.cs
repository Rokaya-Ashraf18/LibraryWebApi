using LibraryWebApi.LibraryBusiness.DTOs.Book;
using LibraryWebApi.LibraryBusiness.Services;
using LibraryWebApi.LibraryData.Models.Entities;
using LibraryWebApi.LibraryData.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class booksController : ControllerBase
    {
         BookRepository BookRepository { get; }
        public booksController(BookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await BookServices.BooksToGetDto(BookRepository.GetAllAsync().Result);
            if(books== null||books.Count()==0) return NotFound();
            return Ok(books);
         
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByID(int id)
        {
            var book =  BookServices.BookToGetDto(BookRepository.GetByIdAsync(id).Result);
            if (book == null) return NotFound();
    
            return Ok(book);
            
        }
        [HttpGet("available")]
        public async Task<IActionResult> GetAllAvailabkeBooks()
        {
            var books = await BookServices.BooksToGetDto(BookRepository.GetAllAvailabkeBooksAsync().Result);
            if (books == null) return NotFound();
            return Ok(books);
            
        }
        [HttpGet("{id}/category")]
        public async Task<IActionResult> GetBookCategory(int id)
        {
            var books = await BookRepository.GetBookCategoryAsync(id);
            if (books == null) return NotFound();
            return Ok(CategoryServices.CategoryToDTO(books.Category));
            
        }
        [HttpGet("{id}/author")]
        public async Task<IActionResult> GetBookAuthor(int id)
        {
            var book = await BookRepository.GetBookAuthorAsync(id);
            if (book == null) return NotFound();
            return Ok(AuthorServices.AuthorToDTO(book.Author));
            
        }
        [HttpGet("check-stock")]
        public async Task<IActionResult> IsBookInStock(int id, int quantity)
        {
            bool IsInStock = await BookRepository.IsBookInStockAsync(id,quantity);
            return Ok(IsInStock);
            
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookDTO book)
        {
            if (book == null||!ModelState.IsValid) return BadRequest();
        
            Book bookModel = BookServices.DtoToBook(book);
            await BookRepository.AddAsync(bookModel);
            await BookRepository.SaveAsync();
            return CreatedAtAction("GetBookByID", new {ID=bookModel.ID}, book);
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditBook(int id,BookUpdateDTO book)
        {
            if (book == null || !ModelState.IsValid) return BadRequest();
            Book bookModel = BookServices.UpdateDtoToBook(book);
            await BookRepository.Update(id,bookModel);
            await BookRepository.SaveAsync();
            return NoContent();
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await BookRepository.DeleteAsync(id);
            await BookRepository.SaveAsync();
            return NoContent();
            
        }

        
        
    }
}
