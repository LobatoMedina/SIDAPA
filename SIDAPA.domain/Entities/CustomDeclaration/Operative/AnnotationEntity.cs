using SIDAPA.domain.Entities.Core.Operative;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_anotacion</c>: Correcciones del Glosador (HU-18, HU-19). (Origen: Sistema)
/// </summary>
public class AnnotationEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Pedimento.</summary>
    public int PedimentoId { get; set; }
    /// <summary>Partida, si la anotación es de una partida.</summary>
    public int? PartidaId { get; set; }
    /// <summary>Campo señalado.</summary>
    public string Field { get; set; } = null!;
    /// <summary>Qué corregir.</summary>
    public string Comment { get; set; } = null!;
    /// <summary>Abierta o Corregida.</summary>
    public string Status { get; set; } = null!;
    /// <summary>Quién la dejó.</summary>
    public int GlosadorId { get; set; }
    /// <summary>Fecha.</summary>
    public DateTime CreatedAt { get; set; }

    public PedimentoEntity Pedimento { get; set; } = null!;
    public PartidaEntity? Partida { get; set; }
    public UserEntity Glosador { get; set; } = null!;
}
