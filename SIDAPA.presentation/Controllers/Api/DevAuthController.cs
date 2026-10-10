using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIDAPA.application.DTOs.Core.Auth;
using SIDAPA.application.Interface.Core;
using SIDAPA.presentation.Security;

namespace SIDAPA.presentation.Controllers.Api;

[ApiController]
[Route("api/dev/auth")]
public class DevAuthController(ITokenService tokenService) : ControllerBase
{
    [HttpPost("token")]
    public IActionResult Token(string role = "Capturador")
    {
        var token = tokenService.CreateToken(new UserSessionDto(1, "Usuario de prueba", "prueba@sidapa.mx", role, null));
        AuthCookie.Write(Response, token);
        return Ok(token);
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me() => Ok(User.Claims.Select(c => new { c.Type, c.Value }));

    [Authorize(Roles = "Glosador")]
    [HttpGet("solo-glosador")]
    public IActionResult OnlyGlosador() => Ok("Eres Glosador");
}