namespace LibraryWebApi.LibraryData.Models.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public override string ToString()
        {
            return $"Name : {Name}\nDescription : {Description}";
        }
    }
}
