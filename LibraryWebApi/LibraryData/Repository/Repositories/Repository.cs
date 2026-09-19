using LibraryWebApi.LibraryData;
using LibraryWebApi.LibraryData.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.LibraryData.Repository.Repositories
{
    public class Repository<T>  : IRepository<T> where T : class
    {
        public Context _context;

        public Repository(Context context)
        {
            this._context = context;
        }

        public async Task AddAsync(T entity)
        {
            if (entity != null)
            { 
                await _context.Set<T>().AddAsync(entity);
            }
        }

        public async Task DeleteAsync(int id)
        {
            T? del = await _context.Set<T>().FindAsync(id);
            if (del != null)
            {
                _context.Set<T>().Remove(del);
            }
        }

        virtual public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

       virtual public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, T entity)
        {
            T? obj = await _context.Set<T>().FindAsync(id);
            if (obj != null)
            {
                 _context.Set<T>().Update(entity);
            }
        }
    }
}
