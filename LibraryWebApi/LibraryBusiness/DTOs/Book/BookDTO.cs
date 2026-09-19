namespace LibraryWebApi.LibraryBusiness.DTOs.Book
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Edition { get; set; }
        public decimal Price { get; set; }
        public int PublicationYear { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryID { get; set; }
        public int AuthorID { get; set; }
    }
}
