using LibraryWebApi.LibraryData;
using LibraryWebApi.LibraryData.Models.Entities;
using LibraryWebApi.LibraryData.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.LibraryData.Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context):base(context) { }

        public async Task<IEnumerable<Book>> GetBooksByCategoryIDAsync(int categoryID)
        {
            var category = await _context.Category
                        .Include(c => c.Books)
                        .ThenInclude(b => b.Author)
                        .FirstOrDefaultAsync(c => c.ID == categoryID);

            if (category == null)
                return Enumerable.Empty<Book>();

            return category.Books.ToList();
        
        }
    }
}
