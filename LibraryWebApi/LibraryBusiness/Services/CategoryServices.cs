using LibraryWebApi.LibraryBusiness.DTOs.Category;
using LibraryWebApi.LibraryData.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.LibraryBusiness.Services
{
    public class CategoryServices
    {
        public static Category DtoToCategory(CategoryDTO category)
        {
            Category _category = new Category()
            {
                ID = category.ID,
                Name = category.Name,
                Description = category.Description,
            };
            return _category;
        }
        public static CategoryDTO CategoryToDTO(Category category)
        {
            CategoryDTO _category = new CategoryDTO()
            {
                ID = category.ID,
                Name = category.Name,
                Description = category.Description,
            };
            return _category;
        }
        public static async Task<IEnumerable<CategoryDTO>> CategoriesToDTO(IEnumerable<Category> repo)
        {
         
            List<CategoryDTO> result = new();

            foreach (var category in repo)
            {
                result.Add(CategoryToDTO(category));
            }

            return result;
        }
        public static Category CreateDtoToCategory(CategoryCreateDTO category)
        {
            Category _category = new Category()
            {
                Name = category.Name,
                Description = category.Description,
            };
            return _category;
        }
    }
}
