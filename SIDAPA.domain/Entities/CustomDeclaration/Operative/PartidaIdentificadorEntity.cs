using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_identificador_partida</c>: Identificadores de cada partida. (Origen: Anexo 22 (identificadores P))
/// </summary>
public class PartidaIdentificadorEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Partida.</summary>
    public int PartidaId { get; set; }
    /// <summary>Identificador (debe ser de nivel P).</summary>
    public int IdentificadorId { get; set; }
    /// <summary>Complemento 1.</summary>
    public string? Complement1 { get; set; }
    /// <summary>Complemento 2.</summary>
    public string? Complement2 { get; set; }
    /// <summary>Complemento 3.</summary>
    public string? Complement3 { get; set; }

    public PartidaEntity Partida { get; set; } = null!;
    public IdentificadorEntity Identificador { get; set; } = null!;
}
