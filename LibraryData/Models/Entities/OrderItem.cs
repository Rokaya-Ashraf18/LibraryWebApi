using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApi.LibraryData.Models.Entities
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [ForeignKey("OrderID")]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("BookID")]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
    }
}
