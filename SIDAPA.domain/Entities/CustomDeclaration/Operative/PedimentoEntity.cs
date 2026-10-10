using SIDAPA.domain.Entities.Core.Catalogs;
using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_pedimento</c>: Encabezado del pedimento. (Origen: Anexo 22 (encabezado))
/// </summary>
public class PedimentoEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Referencia (un pedimento por referencia).</summary>
    public int ReferenciaId { get; set; }
    /// <summary>Año (2) + aduana (2) + patente (4) + consecutivo (7).</summary>
    public string? PedimentoNumber { get; set; }
    /// <summary>Patente.</summary>
    public string Patente { get; set; } = null!;
    /// <summary>1 importación, 2 exportación.</summary>
    public short OperationTypeCode { get; set; }
    /// <summary>Clave de pedimento.</summary>
    public string PedimentoKeyCode { get; set; } = null!;
    /// <summary>Régimen.</summary>
    public string CustomsRegimeCode { get; set; } = null!;
    /// <summary>Destino/origen.</summary>
    public string GoodsDestinationCode { get; set; } = null!;
    /// <summary>Aduana de despacho.</summary>
    public string ClearanceAduanaCode { get; set; } = null!;
    /// <summary>Aduana de entrada/salida.</summary>
    public string? EntryAduanaCode { get; set; }
    /// <summary>Medio de transporte de entrada/salida.</summary>
    public string EntryTransportModeCode { get; set; } = null!;
    /// <summary>Medio de arribo.</summary>
    public string ArrivalTransportModeCode { get; set; } = null!;
    /// <summary>Medio de salida.</summary>
    public string ExitTransportModeCode { get; set; } = null!;
    /// <summary>Tipo de cambio.</summary>
    public decimal ExchangeRate { get; set; }
    /// <summary>Peso bruto en kg.</summary>
    public decimal GrossWeight { get; set; }
    /// <summary>Valor en dólares.</summary>
    public decimal ValueInUsd { get; set; }
    /// <summary>Valor en aduana.</summary>
    public decimal CustomsValue { get; set; }
    /// <summary>Precio pagado o valor comercial.</summary>
    public decimal CommercialValue { get; set; }
    /// <summary>Incrementables: fletes.</summary>
    public decimal Freight { get; set; }
    /// <summary>Incrementables: seguros.</summary>
    public decimal Insurance { get; set; }
    /// <summary>Incrementables: embalajes.</summary>
    public decimal Packaging { get; set; }
    /// <summary>Otros incrementables.</summary>
    public decimal OtherIncrementables { get; set; }
    /// <summary>Fecha de entrada.</summary>
    public DateOnly? EntryDate { get; set; }
    /// <summary>Fecha de pago.</summary>
    public DateOnly? PaymentDate { get; set; }
    /// <summary>Total de contribuciones en efectivo.</summary>
    public decimal TotalCash { get; set; }
    /// <summary>Total en otras formas de pago.</summary>
    public decimal TotalOther { get; set; }
    /// <summary>Borrador, En glosa, Glosado, Archivo generado, Validado o Rechazado.</summary>
    public string Status { get; set; } = null!;
    /// <summary>Quién dio el visto bueno.</summary>
    public int? GlosadorId { get; set; }

    public ReferenciaEntity Referencia { get; set; } = null!;
    public CustomsBrokerEntity CustomsBroker { get; set; } = null!;
    public OperationTypeEntity OperationType { get; set; } = null!;
    public PedimentoKeyEntity PedimentoKey { get; set; } = null!;
    public CustomsRegimeEntity CustomsRegime { get; set; } = null!;
    public GoodsDestinationEntity GoodsDestination { get; set; } = null!;
    public AduanaEntity ClearanceAduana { get; set; } = null!;
    public AduanaEntity? EntryAduana { get; set; }
    public TransportModeEntity EntryTransportMode { get; set; } = null!;
    public TransportModeEntity ArrivalTransportMode { get; set; } = null!;
    public TransportModeEntity ExitTransportMode { get; set; } = null!;
    public UserEntity? Glosador { get; set; }

    public ICollection<PedimentoTransportEntity> Transports { get; set; } = [];
    public ICollection<WaybillEntity> Waybills { get; set; } = [];
    public ICollection<ContainerEntity> Containers { get; set; } = [];
    public ICollection<PedimentoIdentificadorEntity> Identificadores { get; set; } = [];
    public ICollection<PedimentoTaxEntity> Taxes { get; set; } = [];
    public ICollection<PartidaEntity> Partidas { get; set; } = [];
    public ICollection<AnnotationEntity> Annotations { get; set; } = [];
    public ICollection<ValidationFileEntity> ValidationFiles { get; set; } = [];
}
