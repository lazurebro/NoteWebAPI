using Microsoft.AspNetCore.Mvc;
using NoteService.WebAPI.DTO;
using NoteService.BusinessLogic.Interfaces;

namespace NoteService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            try
            {
                await authService.RegisterUserAsync(
                    registerRequest.Username,
                    registerRequest.Email,
                    registerRequest.Password
                    );

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var token = await authService.LoginUserAsync(
                    loginRequest.Username,
                    loginRequest.Password);

                return Ok(new { jwt_token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
