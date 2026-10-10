using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.CustomDeclaration.Operative;

/// <summary>
/// Tabla <c>ope_partida</c>: Mercancías declaradas en el pedimento. (Origen: Anexo 22 (partidas))
/// </summary>
public class PartidaEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Pedimento.</summary>
    public int PedimentoId { get; set; }
    /// <summary>Consecutivo.</summary>
    public short PartidaNumber { get; set; }
    /// <summary>Fracción arancelaria y NICO de la partida.</summary>
    public int FraccionArancelariaId { get; set; }
    /// <summary>Descripción.</summary>
    public string Description { get; set; } = null!;
    /// <summary>Método de valoración.</summary>
    public string ValuationMethodCode { get; set; } = null!;
    /// <summary>Unidad comercial.</summary>
    public string CommercialUnitCode { get; set; } = null!;
    /// <summary>Cantidad comercial.</summary>
    public decimal CommercialQuantity { get; set; }
    /// <summary>Unidad de tarifa.</summary>
    public string TariffUnitCode { get; set; } = null!;
    /// <summary>Cantidad de tarifa.</summary>
    public decimal TariffQuantity { get; set; }
    /// <summary>País de origen.</summary>
    public string OriginCountryCode { get; set; } = null!;
    /// <summary>País vendedor/comprador.</summary>
    public string SellerCountryCode { get; set; } = null!;
    /// <summary>Valor en aduana.</summary>
    public decimal CustomsValue { get; set; }
    /// <summary>Precio pagado o valor comercial.</summary>
    public decimal PricePaid { get; set; }
    /// <summary>Precio unitario.</summary>
    public decimal UnitPrice { get; set; }
    /// <summary>Valor agregado (exportación IMMEX).</summary>
    public decimal? AddedValue { get; set; }

    public PedimentoEntity Pedimento { get; set; } = null!;
    public FraccionArancelariaEntity FraccionArancelaria { get; set; } = null!;
    public ValuationMethodEntity ValuationMethod { get; set; } = null!;
    public UnitOfMeasureEntity CommercialUnit { get; set; } = null!;
    public UnitOfMeasureEntity TariffUnit { get; set; } = null!;
    public CountryEntity OriginCountry { get; set; } = null!;
    public CountryEntity SellerCountry { get; set; } = null!;

    public ICollection<PartidaTaxEntity> Taxes { get; set; } = [];
    public ICollection<PartidaIdentificadorEntity> Identificadores { get; set; } = [];
    public ICollection<PartidaPermitEntity> Permits { get; set; } = [];
    public ICollection<AnnotationEntity> Annotations { get; set; } = [];
}
