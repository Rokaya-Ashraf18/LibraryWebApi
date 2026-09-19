using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryWebApi.LibraryData.Models.Entities
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear {  get; set; }
        public int StockQuantity {  get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<OrderItem> OrderItem { get; set; }
    }
}
