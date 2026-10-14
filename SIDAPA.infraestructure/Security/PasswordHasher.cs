using Microsoft.AspNetCore.Identity;
using SIDAPA.application.Interface.Core;
using SIDAPA.domain.Entities.Core.Operative;

namespace SIDAPA.infraestructure.Security;

/// <summary>
/// Envuelve <see cref="PasswordHasher{TUser}"/> de ASP.NET Core Identity
/// (PBKDF2-HMAC-SHA512, 100 000 iteraciones, sal aleatoria de 128 bits, formato versionado).
/// </summary>
public class PasswordHasher : IPasswordHasher
{
    private readonly PasswordHasher<UserEntity> _hasher = new();

    public string Hash(string password) => _hasher.HashPassword(null!, password);

    public bool Verify(string passwordHash, string password)
    {
        try
        {
            return _hasher.VerifyHashedPassword(null!, passwordHash, password) != PasswordVerificationResult.Failed;
        }
        catch (FormatException)
        {
            return false;   // hash mal formado en la BD: se trata como contraseña incorrecta
        }
    }
}
