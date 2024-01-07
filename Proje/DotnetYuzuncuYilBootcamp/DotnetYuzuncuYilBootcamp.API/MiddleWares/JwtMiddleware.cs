using DotnetYuzuncuYilBootcamp.Core.Services;
using DotnetYuzuncuYilBootcamp.Service.Abstraction;

namespace DotnetYuzuncuYilBootcamp.API.MiddleWares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IEmployeeService employeeService, IJwtAuthenticationManager iJwtAuthenticationManager)
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            string token = null;

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                var parts = authorizationHeader.Split(" ");
                if (parts.Length > 1)
                {
                    token = parts[parts.Length - 1];
                }
            }

            var employeeId = iJwtAuthenticationManager.ValidateJwtToken(token);
            if (employeeId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["Employee"] = employeeService.GetByIdAsync(employeeId.Value).Result;
            }

            await _next(context);
        }
    }
}
