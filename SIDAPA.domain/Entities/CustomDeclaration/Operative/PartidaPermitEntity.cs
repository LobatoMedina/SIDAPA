using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_permiso_partida</c>: Permisos (RRNA) de cada partida (HU-11). (Origen: Anexo 22 (permisos))
/// </summary>
public class PartidaPermitEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Partida.</summary>
    public int PartidaId { get; set; }
    /// <summary>Permiso (dependencia y clave).</summary>
    public int RegulationId { get; set; }
    /// <summary>Número del permiso.</summary>
    public string PermitNumber { get; set; } = null!;
    /// <summary>Firma de descargo.</summary>
    public string? DischargeSignature { get; set; }
    /// <summary>Valor que se descarga del permiso.</summary>
    public decimal? ValueInUsd { get; set; }
    /// <summary>Cantidad que se descarga.</summary>
    public decimal? TariffQuantity { get; set; }

    public PartidaEntity Partida { get; set; } = null!;
    public RegulationEntity Regulation { get; set; } = null!;
}
