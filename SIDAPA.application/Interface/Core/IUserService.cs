using SIDAPA.application.DTOs.Core.Auth;

namespace SIDAPA.application.Interface.Core;

public interface IUserService
{
    /// <summary>Valida correo y contraseña; si son correctos regresa los datos de la sesión.</summary>
    Task<LoginResultDto> LoginAsync(string email, string password, CancellationToken ct = default);
}
