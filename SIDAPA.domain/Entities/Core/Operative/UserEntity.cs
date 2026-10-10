using SIDAPA.domain.Entities.Core.Catalogs;

namespace SIDAPA.domain.Entities.Core.Operative;

/// <summary>
/// Tabla <c>ope_usuario</c>: Personas que entran al sistema. (Origen: Sistema)
/// </summary>
public class UserEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Nombre completo.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Correo con el que inicia sesión.</summary>
    public string Email { get; set; } = null!;
    /// <summary>Contraseña cifrada (hash con sal).</summary>
    public string PasswordHash { get; set; } = null!;
    /// <summary>Rol.</summary>
    public short RoleId { get; set; }
    /// <summary>Empresa, solo para el rol Cliente.</summary>
    public int? ClientId { get; set; }
    /// <summary>Intentos de inicio de sesión fallidos (bloqueo a los 5, HU-01).</summary>
    public short FailedLoginAttempts { get; set; }
    /// <summary>Fin del bloqueo temporal.</summary>
    public DateTime? LockedUntil { get; set; }
    /// <summary>Si puede entrar.</summary>
    public bool IsActive { get; set; }

    public RoleEntity Role { get; set; } = null!;
    public ClientEntity? Client { get; set; }
}
