using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_contenedor</c>: Contenedores y candados. (Origen: Anexo 22 (contenedores))
/// </summary>
public class ContainerEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Pedimento.</summary>
    public int PedimentoId { get; set; }
    /// <summary>Número de contenedor (por ejemplo CSQU3054383).</summary>
    public string Number { get; set; } = null!;
    /// <summary>Tipo de contenedor.</summary>
    public string ContainerTypeCode { get; set; } = null!;
    /// <summary>Candados fiscales.</summary>
    public string? Seals { get; set; }

    public PedimentoEntity Pedimento { get; set; } = null!;
    public ContainerTypeEntity ContainerType { get; set; } = null!;
}
