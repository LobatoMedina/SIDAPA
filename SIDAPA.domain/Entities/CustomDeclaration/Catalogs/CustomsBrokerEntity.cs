namespace SIDAPA.domain.Entities.CustomDeclaration.Catalogs;

/// <summary>
/// Tabla <c>cat_agente_aduanal</c>: Patentes con las que se pueden transmitir los pedimentos. (Origen: Configuración)
/// </summary>
public class CustomsBrokerEntity
{
    /// <summary>Número de patente (forma parte del número de pedimento).</summary>
    public string Patente { get; set; } = null!;
    /// <summary>Nombre del agente aduanal o de la agencia.</summary>
    public string Name { get; set; } = null!;
    /// <summary>RFC del agente o agencia.</summary>
    public string Rfc { get; set; } = null!;
    /// <summary>Agente, Agencia o Apoderado.</summary>
    public string Type { get; set; } = null!;
    /// <summary>Aduana de adscripción.</summary>
    public string AduanaCode { get; set; } = null!;
    /// <summary>Si la patente está vigente.</summary>
    public bool IsActive { get; set; }

    public AduanaEntity Aduana { get; set; } = null!;
}
