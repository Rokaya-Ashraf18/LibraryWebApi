using LibraryWebApi.LibraryData;
using LibraryWebApi.LibraryData.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.LibraryData.Repository.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(Context context):base(context) { }
        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Order
                      .Include(o => o.Customer)
                       .ToListAsync();
        }
        public override async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Order
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.ID == id);
        }
      

    }
}
