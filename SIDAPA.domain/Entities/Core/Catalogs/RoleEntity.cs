namespace SIDAPA.domain.Entities.Core.Catalogs;

/// <summary>
/// Tabla <c>cat_rol</c>: Roles del sistema. (Origen: Sistema)
/// </summary>
public class RoleEntity
{
    /// <summary>Identificador.</summary>
    public short Id { get; set; }
    /// <summary>Cliente, Capturador, Glosador o Administrador.</summary>
    public string Name { get; set; } = null!;
}
