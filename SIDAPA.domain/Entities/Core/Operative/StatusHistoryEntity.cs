using SIDAPA.domain.Entities.Core.Catalogs;

namespace SIDAPA.domain.Entities.Core.Operative;

/// <summary>
/// Tabla <c>ope_bitacora_estatus</c>: Historial de cambios de estatus. (Origen: Sistema)
/// </summary>
public class StatusHistoryEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Referencia.</summary>
    public int ReferenciaId { get; set; }
    /// <summary>Estatus nuevo.</summary>
    public short StatusId { get; set; }
    /// <summary>Quién lo cambió.</summary>
    public int UserId { get; set; }
    /// <summary>Cuándo.</summary>
    public DateTime ChangedAt { get; set; }
    /// <summary>Motivo del cambio.</summary>
    public string? Comment { get; set; }

    public ReferenciaEntity Referencia { get; set; } = null!;
    public StatusEntity Status { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
}
