using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Core.Dto;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                _authService.Register(registerDto);
                return Ok("Kayıt başarılı.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Kayıt başarısız: {ex.Message}");
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var token = _authService.Login(loginDto);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return Unauthorized($"Giriş başarısız: {ex.Message}");
            }
        }
    }
}
