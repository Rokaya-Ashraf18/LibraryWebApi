using Microsoft.AspNetCore.Identity;

namespace LibraryWebApi.LibraryData.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Order> Order { get; set; }
    }
}
