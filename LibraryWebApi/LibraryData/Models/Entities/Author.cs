namespace LibraryWebApi.LibraryData.Models.Entities
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Nationality {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
