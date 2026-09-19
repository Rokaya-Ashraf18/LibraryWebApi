using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi.LibraryBusiness.DTOs.Account
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
