using DotnetYuzuncuYilBootcamp.Core.DTOs.Authentication;

namespace DotnetYuzuncuYilBootcamp.API.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string userName, string password);
    }
}
