using SIDAPA.application.DTOs.Core.Auth;

namespace SIDAPA.presentation.Security;

public static class AuthCookie
{
    public const string Name = "sidapa_token";

    public static void Write(HttpResponse response , AuthToken token) =>
        response.Cookies.Append(Name , token.AccessToken, new CookieOptions
        {
           HttpOnly = true,
           Secure = true,
           SameSite = SameSiteMode.Strict,
           Expires = token.ExpiresAtUtc
        });

    public static void Delete(HttpResponse response) => response.Cookies.Delete(Name);
}