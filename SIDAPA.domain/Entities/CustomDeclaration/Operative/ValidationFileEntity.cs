namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_archivo_validacion</c>: Archivos de validación generados y respuesta del validador (HU-20, HU-21). (Origen: Lineamientos VOCE-SAAI M3)
/// </summary>
public class ValidationFileEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Pedimento.</summary>
    public int PedimentoId { get; set; }
    /// <summary>Nombre mppppnnn.ddd.</summary>
    public string FileName { get; set; } = null!;
    /// <summary>Ubicación.</summary>
    public string BucketPath { get; set; } = null!;
    /// <summary>Fecha.</summary>
    public DateTime GeneratedAt { get; set; }
    /// <summary>Aceptado o Rechazado.</summary>
    public string? Result { get; set; }
    /// <summary>Acuse de validación (8 caracteres).</summary>
    public string? Acknowledgment { get; set; }
    /// <summary>Errores del validador.</summary>
    public string? ResponseDetail { get; set; }

    public PedimentoEntity Pedimento { get; set; } = null!;
}
