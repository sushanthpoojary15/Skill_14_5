using CollaboSphere.Common.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CollaboSphere.Web.API
{


    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/api/auth/login" && context.Request.Method == "POST")
            {
                await _next(context);
                return;
            }

            if (context.Request.Headers.TryGetValue("Authorization", out var token) && token.ToString().StartsWith("Bearer "))
            {
                var tokenString = token.ToString().Substring("Bearer ".Length);
                var principal = new JwtSecurityTokenHandler().ValidateToken(tokenString, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey"))
                }, out _);

                context.Items["User"] = principal;
            }

            await _next(context);
        }
    }
}
