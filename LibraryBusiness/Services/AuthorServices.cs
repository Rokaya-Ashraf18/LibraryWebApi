using LibraryWebApi.LibraryBusiness.DTOs.Author;
using LibraryWebApi.LibraryData.Models.Entities;

namespace LibraryWebApi.LibraryBusiness.Services
{
    public class AuthorServices
    {
        public static Author CreateDtoToAuthor(AuthorCreateDTO authorCreateDTO)
        {
            Author author = new Author()
            {
                Name = authorCreateDTO.Name,
                DateOfBirth = authorCreateDTO.DateOfBirth,
                Nationality = authorCreateDTO.Nationality,
            };
            return author;
        }
        public static Author DtoToAuthor(AuthorDTO authorDTO)
        {
            Author author = new Author()
            {
                ID=authorDTO.ID,
                Name = authorDTO.Name,
                DateOfBirth = authorDTO.DateOfBirth,
                Nationality = authorDTO.Nationality,
            };
            return author;
        }
        public static AuthorDTO AuthorToDTO(Author author)
        {
            AuthorDTO _author = new AuthorDTO()
            {
                ID=author.ID,
                Name = author.Name,
                DateOfBirth = author.DateOfBirth,
                Nationality = author.Nationality,
            };
            return _author;
        }
        public static async Task<IEnumerable<AuthorDTO>> AuthorsToDTO(IEnumerable<Author> authors)
        {
            List<AuthorDTO> _authors = new();
            foreach (var item in authors)
            {
                _authors.Add(AuthorToDTO(item));
                
            }
           
            return  _authors;
        }
    }
}
