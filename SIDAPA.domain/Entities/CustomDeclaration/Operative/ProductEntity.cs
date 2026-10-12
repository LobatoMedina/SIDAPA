using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_producto</c>: Catálogo de partes por cliente con fracción pre-validada. (Origen: Sistema)
/// </summary>
public class ProductEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Cliente.</summary>
    public int ClientId { get; set; }
    /// <summary>Número de parte (único por cliente).</summary>
    public string PartNumber { get; set; } = null!;
    /// <summary>Descripción para el pedimento.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Fracción y NICO aprobados.</summary>
    public int? FraccionArancelariaId { get; set; }
    /// <summary>Pendiente o Aprobado.</summary>
    public string Status { get; set; } = null!;
    /// <summary>Quién aprobó.</summary>
    public int? GlosadorId { get; set; }
    /// <summary>Cuándo.</summary>
    public DateTime? ApprovedAt { get; set; }

    public ClientEntity Client { get; set; } = null!;
    public FraccionArancelariaEntity? FraccionArancelaria { get; set; }
    public UserEntity? Glosador { get; set; }
}
