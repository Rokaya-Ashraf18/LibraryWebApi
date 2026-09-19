using LibraryWebApi.LibraryData.Models.Entities;

namespace LibraryWebApi.LibraryData.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerAsync(string customerId);

        Task<Order?> GetOrderWithItemsAsync(int id);
    }
}
