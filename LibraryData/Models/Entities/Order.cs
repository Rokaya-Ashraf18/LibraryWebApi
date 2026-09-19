using LibraryWebApi.LibraryData.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.WebRequestMethods;

namespace LibraryWebApi.LibraryData.Models.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public decimal TotalAmount {  get; set; } 
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        [ForeignKey("Customer")]
        public string CustomerID { get; set; }
        public virtual ApplicationUser Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
