using System.Collections.Generic;
namespace LibraryWebApi.LibraryData.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task Update(int id, T entity);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
