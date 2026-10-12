using SIDAPA.domain.Enums.Core;
using SIDAPA.domain.Exceptions.CoreException;
using static SIDAPA.domain.Enums.Core.ReferenciaStatusEnum;

namespace SIDAPA.domain.Rules.Core;

public static class ReferenciaStatusFlow
{
    private static readonly Dictionary<ReferenciaStatusEnum, ReferenciaStatusEnum[]> Allowed = new()
    {
        [RECIBIDA]                = [EN_REVISION],
        [EN_REVISION]             = [EN_ESPERA_DE_DOCUMENTOS, EXPEDIENTE_COMPLETO],
        [EN_ESPERA_DE_DOCUMENTOS] = [EN_REVISION],
        [EXPEDIENTE_COMPLETO]     = [FACTURA_LEIDA],
        [FACTURA_LEIDA]           = [FACTURA_CONFIRMADA],
        [FACTURA_CONFIRMADA]      = [EN_CLASIFICACION, BORRADOR_DE_PEDIMENTO],
        [EN_CLASIFICACION]        = [BORRADOR_DE_PEDIMENTO],
        [BORRADOR_DE_PEDIMENTO]   = [EN_GLOSA],
        [EN_GLOSA]                = [CON_ANOTACIONES, GLOSADO],
        [CON_ANOTACIONES]         = [EN_GLOSA],
        [GLOSADO]                 = [ARCHIVO_GENERADO],
        [ARCHIVO_GENERADO]        = [VALIDADO, RECHAZADO_POR_VALIDADOR],
        [RECHAZADO_POR_VALIDADOR] = [CON_ANOTACIONES],
        [VALIDADO]                = [CERRADO],
        [CERRADO]                 = []
    };

    public static bool CanChange(ReferenciaStatusEnum from, ReferenciaStatusEnum to) =>
        Allowed.TryGetValue(from, out var next) && next.Contains(to);

    public static void EnsureCanChange(ReferenciaStatusEnum from, ReferenciaStatusEnum to)
    {
        if (!CanChange(from, to))
            throw new DomainException($"La referencia no puede pasar de {from} a {to}.");
    }
}