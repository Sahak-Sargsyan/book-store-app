using AuthService.Data;
using AuthService.Dtos;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Services
{
    public class AuthenticationService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public AuthenticationService(UserManager<User> userManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
                return new LoginResponseDto() { Token = string.Empty };

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);

            if (!isValid)
            {
                return new LoginResponseDto() { Token = string.Empty };
            }

            var token = await _jwtProvider.Generate(user)
                ?? throw new ArgumentNullException("Token generation failed.");

            var response = new LoginResponseDto() { Token = "Bearer " + token };

            return response;
        }

        public Task Register(RegisterRequestDto registerRequest)
        {
            throw new NotImplementedException();
        }
    }
}
