using ListasEnlazadasDobles.Models;

namespace ListasEnlazadasDobles.Services
{
    public class ListaEnlazadaDoble
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }
        public Nodo? NodoActual { get; set; }

        public ListaEnlazadaDoble()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            NodoActual = null;
        }

        public bool IsEmpty => PrimerNodo == null;

        // Métodos existentes...
        // ...

        // Método para insertar un nodo al inicio de la lista.
        public string InsertarAlInicio(Nodo nuevoNodo)
        {
            try
            {
                if (nuevoNodo == null)
                {
                    throw new ArgumentNullException(nameof(nuevoNodo), "El nodo proporcionado es nulo.");
                }

                if (IsEmpty)
                {
                    PrimerNodo = nuevoNodo;
                    UltimoNodo = nuevoNodo;
                }
                else
                {
                    nuevoNodo.LigaSiguiente = PrimerNodo;
                    PrimerNodo.LigaAnterior = nuevoNodo;
                    PrimerNodo = nuevoNodo;
                }

                NodoActual = nuevoNodo;
                return "Nodo insertado al inicio.";
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed.
                return $"Error al insertar al inicio: {ex.Message}";
            }
        }

        // Método para eliminar un nodo antes de una posición específica.
        public string EliminarAntesDePosicion(int posicion)
        {
            try
            {
                if (posicion <= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(posicion), "La posición debe ser mayor que 1.");
                }

                // Resto del código...

                return "Nodo eliminado antes de la posición.";
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed.
                return $"Error al eliminar antes de la posición: {ex.Message}";
            }
        }

        // Método para eliminar un nodo después de una posición específica.
        public string EliminarDespuesDePosicion(int posicion)
        {
            try
            {
                if (posicion < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(posicion), "La posición no puede ser negativa.");
                }

                // Resto del código...

                return "Nodo eliminado después de la posición.";
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed.
                return $"Error al eliminar después de la posición: {ex.Message}";
            }
        }

        // Continuación de otros métodos existentes...
        // ...
    }
}
