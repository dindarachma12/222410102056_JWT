using Microsoft.AspNetCore.Mvc;
using percobaan1.DTO;
using percobaan1.Entities;
using percobaan1.Repositories.Impl;
using percobaan1.Services;
using percobaan1.Services.Impl;
namespace percobaan1.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private string credentials;
        private IConfiguration configuration;
        private AuthServiceImpl authService;
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.credentials = configuration.GetConnectionString("WebApiDatabase");
            this.authService = new AuthServiceImpl(new AuthRepositoryImpl(new percobaan1.Utils.DbUtils(this.credentials)));
        }

        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] RegisterDTO dto)
        {
            User user = new User();
            user.nama = dto.nama;
            user.alamat = dto.alamat;
            user.email = dto.email;
            user.password = dto.password;
            User registeredUser = this.authService.register(dto);
            if (registeredUser == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(registeredUser);
            }
        }

        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] LoginDTO dto)
        {
            User user = new User();
            user.email = dto.email;
            user.password = dto.password;
            User LoggedIn = this.authService.Login(dto, configuration);
            if (LoggedIn == null)
            {
                return BadRequest();
            }
            return Ok(this.authService.Login(dto, configuration));
        }
    }
}
