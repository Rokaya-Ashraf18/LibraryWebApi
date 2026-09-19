using LibraryWebApi.LibraryBusiness.DTOs.OrderItem;
using LibraryWebApi.LibraryData.Models.Entities;
using LibraryWebApi.LibraryData.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi.LibraryBusiness.DTOs.Order
{
    public class OrderCreateDTO
    {
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [Required]
        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
