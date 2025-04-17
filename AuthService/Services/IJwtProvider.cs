using AuthService.Data;
namespace AuthService.Services;

public interface IJwtProvider
{
    Task<string> Generate(User user);
}
