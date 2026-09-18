using LibraryWebApi.LibraryData.Models.Entities;

namespace LibraryWebApi.LibraryData.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Book>> GetBooksByCategoryIDAsync(int categoryID);
    }
}
