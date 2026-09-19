using LibraryWebApi.LibraryBusiness.DTOs.Author;
using LibraryWebApi.LibraryBusiness.Services;
using LibraryWebApi.LibraryData.Models.Entities;
using LibraryWebApi.LibraryData.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authorsController : ControllerBase
    {
        AuthorRepository AuthorRepository { get; }
        public authorsController(AuthorRepository authorRepository)
        {
            AuthorRepository = authorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await AuthorServices.AuthorsToDTO(AuthorRepository.GetAllAsync().Result);
            return Ok(authors);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorByID(int id)
        {
            var author =  AuthorServices.AuthorToDTO(AuthorRepository.GetByIdAsync(id).Result);
            return Ok(author);

        }
        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetAuthorBooks(int id)
        {
            var books = await BookServices.BooksByAuthorIDToGetDto(AuthorRepository, id);
            if (books == null) return NotFound();
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorCreateDTO author)
        {
            Author _author= AuthorServices.CreateDtoToAuthor(author);
            await AuthorRepository.AddAsync(_author);
            await AuthorRepository.SaveAsync();
            return CreatedAtAction("GetAuthorByID", new { ID = _author.ID }, author);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAuthor(int id, AuthorDTO author)
        {
            Author _author = AuthorServices.DtoToAuthor(author);
            await AuthorRepository.Update(id, _author);
            await AuthorRepository.SaveAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await AuthorRepository.DeleteAsync(id);
            await AuthorRepository.SaveAsync();
            return NoContent();

        }

    }
}
