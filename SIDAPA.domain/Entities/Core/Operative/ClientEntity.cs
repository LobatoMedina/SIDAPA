using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.domain.Entities.Core.Operative;

/// <summary>
/// Tabla <c>ope_cliente</c>: Importadores que atiende la agencia. (Origen: Sistema)
/// </summary>
public class ClientEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>RFC del importador.</summary>
    public string Rfc { get; set; } = null!;
    /// <summary>CURP, solo personas físicas.</summary>
    public string? Curp { get; set; }
    /// <summary>Nombre o razón social.</summary>
    public string BusinessName { get; set; } = null!;
    /// <summary>Domicilio fiscal.</summary>
    public string Address { get; set; } = null!;
    /// <summary>Correo para avisos.</summary>
    public string NotificationEmail { get; set; } = null!;

    public ICollection<UserEntity> Users { get; set; } = [];
    public ICollection<ReferenciaEntity> Referencias { get; set; } = [];
    public ICollection<ProductEntity> Products { get; set; } = [];
}
