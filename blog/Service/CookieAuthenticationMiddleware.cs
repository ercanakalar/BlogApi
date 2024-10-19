using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

public class CookieAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public CookieAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Cookies.ContainsKey("auth"))
        {
            var token = context.Request.Cookies["auth"];

            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);

                var claims = jwtToken.Claims.Select(c => new Claim(c.Type, c.Value)).ToList();
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

                context.User = new ClaimsPrincipal(claimsIdentity);
            }
        }

        await _next(context);
    }
}
