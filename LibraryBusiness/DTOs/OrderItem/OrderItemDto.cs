using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApi.LibraryBusiness.DTOs.OrderItem
{
    public class OrderItemDto
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
 
    }
}
