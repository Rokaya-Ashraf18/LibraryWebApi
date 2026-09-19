using LibraryWebApi.LibraryData.Models.Enum;

namespace LibraryWebApi.LibraryBusiness.DTOs.Order
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
     
    }
}
