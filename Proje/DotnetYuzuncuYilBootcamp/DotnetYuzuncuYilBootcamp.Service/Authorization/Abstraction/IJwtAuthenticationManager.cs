using DotnetYuzuncuYilBootcamp.Core.DTOs.Authentication;

namespace DotnetYuzuncuYilBootcamp.Service.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string userName, string password);
        int? ValidateJwtToken(string token);
    }
}
