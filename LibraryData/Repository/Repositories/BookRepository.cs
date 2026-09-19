using LibraryWebApi.LibraryData;
using LibraryWebApi.LibraryData.Models.Entities;
using LibraryWebApi.LibraryData.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.LibraryData.Repository.Repositories
{
    public class BookRepository : Repository<Book>,IBookRepository
    {
      
        public BookRepository(Context context):base(context) { }
        public override async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Book.Include(b => b.Category).Include(b => b.Author).ToListAsync();
        }
        public override async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Book.Include(b => b.Category).Include(b => b.Author).FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task<IEnumerable<Book>> GetAllAvailabkeBooksAsync()
        {
            return await _context.Book.Include(b => b.Category).Include(b => b.Author).Where(b=>b.StockQuantity>0).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategoryIDAsync(int categoryID)
        {
            return await _context.Book.Include(b => b.Category).Include(b => b.Author).Where(b => b.CategoryID == categoryID).ToListAsync();
        }

        public async Task<Book?> GetBookCategoryAsync(int id) 
        { 
            return await _context.Book.Include(b => b.Category).Include(b => b.Author).FirstOrDefaultAsync(b => b.ID == id); 
        }
        public async Task<Book?> GetBookAuthorAsync(int id) 
        {
            return await _context.Book.Include(b => b.Category).Include(b => b.Author).FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task<bool> IsBookInStockAsync(int id, int quantity)
        {
            var book=await GetByIdAsync(id);
            return book != null && book.StockQuantity >= quantity;
        }
    }
}
