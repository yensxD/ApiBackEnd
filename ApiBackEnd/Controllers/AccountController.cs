using ApiBackEnd.DataAccess;
using ApiBackEnd.Helper.Jwt;
using ApiBackEnd.Models.DataModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackEnd.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        private readonly JwtSettings _jwtSettings;
        public AccountController(AplicationDbContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        // Example
        private IEnumerable<User> logins = new List<User>()
        {
            new User(){Id=1, Email="admin@ejemplo.com",Name="Admin", Password="Admin"},
            new User(){Id=2, Email="pepe@ejemplo.com",Name="User1", Password="Pepe"}
        };

        [HttpPost]
        public IActionResult GetToken(UserLogin userLogin)
        {
            try
            {
                var Token = new UserTokens();

                var searchUser = (from user in _context.User
                                  where user.Name == userLogin.UserName && user.Password == userLogin.Password
                                  select user).FirstOrDefault();

                var valid = logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                if (valid)
                {
                    var user = logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GetTokenKey(new UserTokens()
                    {
                        UserName = user.Name,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid()
                    }, _jwtSettings);

                }
                else
                {
                    return BadRequest("wrong password");
                }

                return Ok(Token);

            }
            catch (Exception exception)
            {

                throw new Exception("GetToken Error", exception);
            }

        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(logins);
        }

    }
}
