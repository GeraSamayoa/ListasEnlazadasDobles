namespace ListasEnlazadasDobles.Validators
{
    public class MensajeValidator
    {
        public static (string? mensajeError, string valor, int? posicion) MensajeInsertar(string mensaje, string? mensajeError, int? posicion, string valor)
        {

            if (mensaje.StartsWith("Nodo agregado"))
            {
                return (null, string.Empty, null);
            }
            else
            {
                return (mensaje, valor, posicion);
            }
        }

        public static (string? mensajeError, int? posicion) MensajeEliminar(string Mensaje, string? mensajeError, int? posicion)
        {
            if (Mensaje.StartsWith("¡Se ha eliminado"))
            {
                return (null, null);
            }
            else
            {
                return (Mensaje, posicion);
            }
        }

        public static string? MensajeOrdenar(string Mensaje, string? mensajeError)
        {
            if (Mensaje.StartsWith("¡Lista ordenada"))
            {
                return mensajeError = null;
            }
            else
            {
                return mensajeError = Mensaje;
            }
        }
    }
}