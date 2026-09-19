using LibraryWebApi.LibraryBusiness.DTOs.Account;
using LibraryWebApi.LibraryBusiness.Services;
using LibraryWebApi.LibraryData.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryWebApi.LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private UserManager<ApplicationUser> userManager;
        private IConfiguration config;
        private  JwtServices _jwtService;

        public AccountController(UserManager<ApplicationUser> UserManager, JwtServices jwtService, IConfiguration config)
        {
            userManager = UserManager;
            this.config = config;
            _jwtService = jwtService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto UserFromRequest)
        {
           
            if (ModelState.IsValid)
            {
                ApplicationUser user = new();
                user.UserName = UserFromRequest.UserName;
                user.Email = UserFromRequest.Email;
                IdentityResult result =
                     await userManager.CreateAsync(user, UserFromRequest.Password);
                if (result.Succeeded)
                {
                    return Ok("Created");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Password", item.Description);
                }
            }
            return BadRequest(ModelState);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginDto UserFromRequest)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userFromDb =
                    await userManager.FindByNameAsync(UserFromRequest.UserName);
                if (userFromDb == null)
                {
                    return NotFound();
                }
                bool found =
                     await userManager.CheckPasswordAsync(userFromDb, UserFromRequest.Password);
                if (found == true)
                {
                  
                    IList<string> roles = await userManager.GetRolesAsync(userFromDb);
                    var token = _jwtService.GenerateToken(userFromDb, roles); 
                   
                    return Ok(new
                    {
                        token = token,
                        expiration = DateTime.Now.AddHours(1)
                    });
                }

                ModelState.AddModelError("UserName", "UserName Or Password InValid");

            }
            return BadRequest(ModelState);
        }
    }
}
