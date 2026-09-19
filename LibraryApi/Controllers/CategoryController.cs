using LibraryWebApi.LibraryBusiness.DTOs.Category;
using LibraryWebApi.LibraryBusiness.Services;
using LibraryWebApi.LibraryData.Models.Entities;
using LibraryWebApi.LibraryData.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryRepository CategoryRepository { get; }
        public CategoryController(CategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await CategoryServices.CategoriesToDTO(CategoryRepository.GetAllAsync().Result);
            return Ok(categories);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByID(int id)
        {
            var category = CategoryServices.CategoryToDTO(CategoryRepository.GetByIdAsync(id).Result);
            return Ok(category);

        }
        [HttpGet("{id}/Books")]
        public async Task<IActionResult> GetBooksInCategory(int id)
        {
            var books = await BookServices.BooksByCategoryIDToGetDto(CategoryRepository, id);
            if (books == null) return NotFound();
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryCreateDTO cat)
        {
            Category category = CategoryServices.CreateDtoToCategory(cat);
            await CategoryRepository.AddAsync(category);
            await CategoryRepository.SaveAsync();
            return CreatedAtAction("GetCategoryByID", new { ID = category.ID }, cat);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory(int id, CategoryDTO category)
        {
            await CategoryRepository.Update(id, CategoryServices.DtoToCategory(category));
            await CategoryRepository.SaveAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await CategoryRepository.DeleteAsync(id);
            await CategoryRepository.SaveAsync();
            return NoContent();

        }

    }
}
