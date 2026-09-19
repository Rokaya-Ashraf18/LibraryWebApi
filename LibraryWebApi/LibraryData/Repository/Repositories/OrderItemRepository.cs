using LibraryWebApi.LibraryData.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.LibraryData.Repository.Repositories
{
    public class OrderItemRepository : Repository<Order>
    {
        public OrderItemRepository(Context context) : base(context) { }
    
        public async Task<IEnumerable<OrderItem>> GetItemsInOrderAsync(int id)
        {
            return await _context.OrderItem
                .Where(oi => oi.OrderID == id)
                .ToListAsync();
        }
    }
}
