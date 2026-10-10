namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_dependencia</c>: Dependencias que emiten regulaciones y restricciones no arancelarias. (Origen: Apéndice 9)
/// </summary>
public class GovernmentAgencyEntity
{
    /// <summary>Identificador.</summary>
    public short Id { get; set; }
    /// <summary>Secretaría de Economía, SADER, Salud, SEMARNAT, SEDENA, SENER, INAH, INBAL, Consejo del Café, Consejo del Tequila o CRE.</summary>
    public string Name { get; set; } = null!;

    public ICollection<RegulationEntity> Regulations { get; set; } = [];
}
