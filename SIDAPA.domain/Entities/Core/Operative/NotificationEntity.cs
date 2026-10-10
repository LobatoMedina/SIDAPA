namespace SIDAPA.domain.Entities.Core.Operative;

/// <summary>
/// Tabla <c>ope_notificacion</c>: Avisos en el panel y por correo. (Origen: Sistema)
/// </summary>
public class NotificationEntity
{
    /// <summary>Identificador.</summary>
    public int Id { get; set; }
    /// <summary>Destinatario.</summary>
    public int UserId { get; set; }
    /// <summary>Referencia relacionada.</summary>
    public int? ReferenciaId { get; set; }
    /// <summary>Texto del aviso.</summary>
    public string Message { get; set; } = null!;
    /// <summary>Si ya la vio.</summary>
    public bool IsRead { get; set; }
    /// <summary>Si se mandó por correo.</summary>
    public bool IsEmailSent { get; set; }
    /// <summary>Fecha.</summary>
    public DateTime CreatedAt { get; set; }

    public UserEntity User { get; set; } = null!;
    public ReferenciaEntity? Referencia { get; set; }
}
