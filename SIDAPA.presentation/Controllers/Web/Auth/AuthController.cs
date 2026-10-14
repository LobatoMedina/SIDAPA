using Microsoft.AspNetCore.Mvc;
using SIDAPA.application.Interface.Core;
using SIDAPA.presentation.Models.Auth;
using SIDAPA.presentation.Security;

namespace SIDAPA.presentation.Controllers.Web.Auth;

public class AuthController(IUserService userService, ITokenService tokenService) : Controller
{
    private const string LoginView = "~/Views/Auth/Login.cshtml";
    private const string InvalidCredentialsMessage = "Correo o contraseña incorrectos.";

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity?.IsAuthenticated == true)
            return RedirectToHome();

        return View(LoginView, new LoginViewModel());
    }

    /// <summary>
    /// Responde JSON si la petición viene de login.js (Accept: application/json);
    /// si no, es un post normal que vuelve a pintar la vista con el error.
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return LoginFailed(model, ModelState.Values.SelectMany(v => v.Errors).First().ErrorMessage);

        var result = await userService.LoginAsync(model.Email, model.Password, ct);
        if (!result.Succeeded)
            return LoginFailed(model, InvalidCredentialsMessage);

        AuthCookie.Write(Response, tokenService.CreateToken(result.Session!));

        var redirectUrl = Url.Action("Index", "Index")!;
        return WantsJson()
            ? Json(new { ok = true, redirectUrl })
            : Redirect(redirectUrl);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        AuthCookie.Delete(Response);
        return RedirectToAction(nameof(Login));
    }

    private IActionResult LoginFailed(LoginViewModel model, string error)
    {
        if (WantsJson())
            return Json(new { ok = false, error });

        model.Password = "";
        ModelState.Clear();
        ModelState.AddModelError(string.Empty, error);
        return View(LoginView, model);
    }

    private bool WantsJson() =>
        Request.Headers.Accept.ToString().Contains("application/json", StringComparison.OrdinalIgnoreCase);

    private IActionResult RedirectToHome() => RedirectToAction("Index", "Index");
}
