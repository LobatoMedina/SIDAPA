using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;
using SIDAPA.domain.Entities.CustomDeclaration.Operative;

namespace SIDAPA.domain.Entities.Core.Operative;

/// <summary>
/// Tabla <c>ope_referencia</c>: Operación de importación; agrupa documentos, facturas y pedimento. (Origen: Sistema)
/// </summary>
public class ReferenciaEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Número que se le da al cliente.</summary>
    public string ReferenciaNumber { get; set; } = null!;
    /// <summary>Cliente.</summary>
    public int ClientId { get; set; }
    /// <summary>Capturador asignado.</summary>
    public int? CapturadorId { get; set; }
    /// <summary>Importación o exportación.</summary>
    public short OperationTypeCode { get; set; }
    /// <summary>Aduana de arribo.</summary>
    public string AduanaCode { get; set; } = null!;
    /// <summary>Conocimiento de embarque.</summary>
    public string? MasterBillOfLading { get; set; }
    /// <summary>Fecha estimada de arribo.</summary>
    public DateOnly? ArrivalDate { get; set; }
    /// <summary>Notas del cliente.</summary>
    public string? Notes { get; set; }
    /// <summary>Estatus actual.</summary>
    public short StatusId { get; set; }
    /// <summary>Fecha del aviso de arribo.</summary>
    public DateTime CreatedAt { get; set; }

    public ClientEntity Client { get; set; } = null!;
    public UserEntity? Capturador { get; set; }
    public OperationTypeEntity OperationType { get; set; } = null!;
    public AduanaEntity Aduana { get; set; } = null!;
    public StatusEntity Status { get; set; } = null!;

    public ICollection<StatusHistoryEntity> StatusHistories { get; set; } = [];
    public ICollection<DocumentEntity> Documents { get; set; } = [];
    public ICollection<DocumentRequestEntity> DocumentRequests { get; set; } = [];
    public ICollection<NotificationEntity> Notifications { get; set; } = [];
    public ICollection<InvoiceEntity> Invoices { get; set; } = [];
    public PedimentoEntity? Pedimento { get; set; }
}
