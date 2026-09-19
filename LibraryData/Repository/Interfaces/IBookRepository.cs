using LibraryWebApi.LibraryData.Models.Entities;

namespace LibraryWebApi.LibraryData.Repository.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllAvailabkeBooksAsync();
        Task<Book> GetBookCategoryAsync(int id);
        Task<bool> IsBookInStockAsync(int id, int quantity);
    }
}
