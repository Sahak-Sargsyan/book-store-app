using AuthService.Dtos;
using BookStore.BLL.Interfaces;
using BookStore.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookStore.WebAPI.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto loginRequest)
        {
            var res = await _authService.Login(loginRequest);

            return Ok(res);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequestDto registerRequest)
        {
            await _authService.Register(registerRequest);
            return Ok();
        }
    }
}
