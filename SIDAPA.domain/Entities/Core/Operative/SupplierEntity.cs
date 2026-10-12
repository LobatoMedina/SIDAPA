using SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

namespace SIDAPA.domain.Entities.Core.Operative;

/// <summary>
/// Tabla <c>ope_proveedor</c>: Proveedores en el extranjero. (Origen: Sistema)
/// </summary>
public class SupplierEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Razón social.</summary>
    public string Name { get; set; } = null!;
    /// <summary>Identificación fiscal en su país.</summary>
    public string TaxId { get; set; } = null!;
    /// <summary>Domicilio.</summary>
    public string Address { get; set; } = null!;
    /// <summary>País del proveedor.</summary>
    public string CountryCode { get; set; } = null!;

    public CountryEntity Country { get; set; } = null!;
}
