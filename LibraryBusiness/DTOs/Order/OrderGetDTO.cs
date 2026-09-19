using LibraryWebApi.LibraryData.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApi.LibraryBusiness.DTOs.Order
{
    public class OrderGetDTO
    {
        public int ID { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string CustomerName { get; set; }
    }
}
