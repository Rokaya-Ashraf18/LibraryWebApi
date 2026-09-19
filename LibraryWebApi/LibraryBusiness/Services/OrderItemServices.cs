using LibraryWebApi.LibraryBusiness.DTOs.OrderItem;
using LibraryWebApi.LibraryData.Models.Entities;

namespace LibraryWebApi.LibraryBusiness.Services
{
    public class OrderItemServices
    {
        public static OrderItem DtoToOrderItem(OrderItemDto orderItemDto)
        {
            OrderItem order = new OrderItem()
            {
                ID = orderItemDto.ID,
                Quantity = orderItemDto.Quantity,
                UnitPrice = orderItemDto.UnitPrice,
                OrderID = orderItemDto.OrderID,
                BookID = orderItemDto.BookID,

            };
            return order;
        }
        public static IEnumerable<OrderItem> DtosToOrderItem(IEnumerable<OrderItemDto> orderItemDto)
        {
            List<OrderItem> order = new();
            foreach (var item in orderItemDto)
            {
                order.Add(DtoToOrderItem(item));
            }
            return order;
        }
    }
}
