using LibraryWebApi.LibraryBusiness.DTOs.Book;
using LibraryWebApi.LibraryData.Models.Entities;
using LibraryWebApi.LibraryData.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.LibraryBusiness.Services
{
    public class BookServices
    {
        public static Book DtoToBook(BookDTO bookDTO)
        {
            Book book = new Book()
            {
           
                Title = bookDTO.Title,
                Edition = bookDTO.Edition,
                Price = bookDTO.Price,
                PublicationYear = bookDTO.PublicationYear,
                StockQuantity = bookDTO.StockQuantity,
                CategoryID = bookDTO.CategoryID,
                AuthorID = bookDTO.AuthorID,

            };
            return book;
        }
        public static Book UpdateDtoToBook(BookUpdateDTO bookDTO)
        {
            Book book = new Book()
            {
                ID = bookDTO.Id,
                Title = bookDTO.Title,
                Edition = bookDTO.Edition,
                Price = bookDTO.Price,
                PublicationYear = bookDTO.PublicationYear,
                StockQuantity = bookDTO.StockQuantity,
                CategoryID = bookDTO.CategoryID,
                AuthorID= bookDTO.AuthorID,

            };
            return book;
        }
        public static BookGetDTO BookToGetDto(Book book)
        {
            BookGetDTO bookModel = new BookGetDTO()
            {
                ID = book.ID,
                Title = book.Title,
                Edition = book.Edition,
                Price = book.Price,
                PublicationYear = book.PublicationYear,
                StockQuantity = book.StockQuantity,
                CategoryName = book.Category?.Name,
                AuthorName=book.Author?.Name

            };
            return bookModel;
        }
        public static async Task<IEnumerable<BookGetDTO>> BooksToGetDto(IEnumerable<Book> books)
        {
            List<BookGetDTO> result = new();
            //var bookList = await books;

            foreach (var book in books)
            {
                result.Add(BookToGetDto(book));
            }

            return result;
        }
       
        public static async Task<IEnumerable<BookGetDTO>> BooksByCategoryIDToGetDto(CategoryRepository repo,int id)
        {
            IEnumerable<Book> books =  repo.GetBooksByCategoryIDAsync(id).Result;

            return await BooksToGetDto(books);
        }
        public static async Task<IEnumerable<BookGetDTO>> BooksByAuthorIDToGetDto(AuthorRepository repo,int id)
        {
            IEnumerable<Book> books =  repo.GetBooksByAuthorIDAsync(id).Result;

            return await BooksToGetDto(books);
        }
    

    }
}
