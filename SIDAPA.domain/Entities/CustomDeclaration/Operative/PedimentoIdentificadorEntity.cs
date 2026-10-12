using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_identificador_pedimento</c>: Identificadores a nivel pedimento. (Origen: Anexo 22 (identificadores G))
/// </summary>
public class PedimentoIdentificadorEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Pedimento.</summary>
    public int PedimentoId { get; set; }
    /// <summary>Identificador (debe ser de nivel G).</summary>
    public int IdentificadorId { get; set; }
    /// <summary>Complemento 1.</summary>
    public string? Complement1 { get; set; }
    /// <summary>Complemento 2.</summary>
    public string? Complement2 { get; set; }
    /// <summary>Complemento 3.</summary>
    public string? Complement3 { get; set; }

    public PedimentoEntity Pedimento { get; set; } = null!;
    public IdentificadorEntity Identificador { get; set; } = null!;
}
