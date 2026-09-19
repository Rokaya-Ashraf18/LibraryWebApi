using LibraryWebApi.LibraryData;
using LibraryWebApi.LibraryData.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.LibraryData.Repository.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(Context context) : base(context) { }
        public async Task<IEnumerable<Book>> GetBooksByAuthorIDAsync(int authorID)
        {
            var _author = await _context.Author
                        .Include(c => c.Books)
                        .ThenInclude(b=>b.Category)
                        .FirstOrDefaultAsync(c => c.ID == authorID);

            if (_author == null)
                return Enumerable.Empty<Book>();

            return _author.Books.ToList();

        }

    }
}
