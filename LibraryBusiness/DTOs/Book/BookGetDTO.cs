namespace LibraryWebApi.LibraryBusiness.DTOs.Book
{
    public class BookGetDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Edition { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public int StockQuantity { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
    }
}
