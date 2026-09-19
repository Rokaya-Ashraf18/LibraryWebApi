using LibraryWebApi.LibraryBusiness.DTOs.Book;
using LibraryWebApi.LibraryBusiness.DTOs.Order;
using LibraryWebApi.LibraryData.Models.Entities;
using LibraryWebApi.LibraryData.Repository.Repositories;

namespace LibraryWebApi.LibraryBusiness.Services
{
    public class OrderServices
    {
        public static Order DtoToOrder(OrderDTO orderDto,string id)
        {
            Order order = new Order()
            {
                ID = orderDto.ID,
                TotalAmount = orderDto.TotalAmount,
                CustomerID = id,
                OrderDate = orderDto.OrderDate,
                Status = orderDto.Status,
                PaymentStatus = orderDto.PaymentStatus,

            };
            return order;
        }
        public static Order CreateDtoToOrder(OrderCreateDTO orderDto,string id)
        {
            Order order = new Order()
            {
                TotalAmount = orderDto.TotalAmount,
                CustomerID = id,
                OrderDate = orderDto.OrderDate,
                Status = orderDto.Status,
                PaymentStatus = orderDto.PaymentStatus,
                OrderItems = (ICollection<OrderItem>)OrderItemServices.DtosToOrderItem(orderDto.OrderItems)

            };
            return order;
        }
        public static OrderGetDTO OrderToGetDTO(Order order)
        {
            OrderGetDTO orderDto = new OrderGetDTO()
            {
                ID = order.ID,
                TotalAmount = order.TotalAmount,
                CustomerName = order.Customer.UserName,
                OrderDate = order.OrderDate,
                Status = order.Status,
                PaymentStatus = order.PaymentStatus,

            };
            return orderDto;
        }
        public static IEnumerable<OrderGetDTO> OrdersToGetDTO(IEnumerable<Order> orders)
        {
            List<OrderGetDTO> ordersDto = new();
            foreach (var item in orders)
            {
                ordersDto.Add(OrderToGetDTO(item));
            }
          
            return ordersDto;
        }
       
    }
}
