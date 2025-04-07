using AuthService.Dtos;

namespace AuthService.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto loginRequest);

        Task Register(RegisterRequestDto registerRequest);
    }
}
