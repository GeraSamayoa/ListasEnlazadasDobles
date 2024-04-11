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

            public string AgregarNodoAlInicio(Nodo nuevoNodo)
            {
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

                return "Nodo agregado al inicio...";
            }

            public Nodo Siguiente()
            {
                NodoActual = NodoActual.LigaSiguiente ?? UltimoNodo;
                return NodoActual;
            }

            public Nodo Anterior()
            {
                NodoActual = NodoActual.LigaAnterior ?? PrimerNodo;
                return NodoActual;
            }
        public string EliminarNodoInicio()
        {
            try
            {
                // Verificar si la lista está vacía
                if (IsEmpty)
                {
                    return "La lista de videos está vacía.";
                }
                else
                {
                    // Si la lista contiene solo un nodo
                    if (PrimerNodo == UltimoNodo)
                    {
                        PrimerNodo = UltimoNodo = null;
                    }
                    else
                    {
                        // Si la lista contiene más de un nodo
                        Nodo temp = PrimerNodo;
                        PrimerNodo = PrimerNodo.LigaSiguiente;
                        if (PrimerNodo != null)
                        {
                            PrimerNodo.LigaAnterior = null;
                        }
                        temp = null;
                    }

                    return "VIDEO ELIMINADO AL INICIO";
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: si ocurre un error, lanzar una excepción con el mensaje de error
                throw new Exception($"Error al eliminar el nodo al inicio: {ex.Message}");
            }
        }

        // Método para insertar un nuevo nodo antes de un dato específico en la lista
        public string InsertarAntesP(string datoX, Nodo nuevoNodo)
        {
            try
            {
                // Verificar si la lista está vacía
                if (IsEmpty)
                {
                    return "La lista está vacía, no se puede insertar el nodo.";
                }

                Nodo nodoActual = PrimerNodo;
                // Recorrer la lista
                while (nodoActual != null)
                {
                    // Verificar si se ha encontrado el dato específico
                    if (nodoActual.Informacion == datoX)
                    {
                        // Insertar el nuevo nodo antes del dato específico
                        if (nodoActual == PrimerNodo)
                        {
                            nuevoNodo.LigaSiguiente = PrimerNodo;
                            PrimerNodo.LigaAnterior = nuevoNodo;
                            PrimerNodo = nuevoNodo;
                        }
                        else
                        {
                            nuevoNodo.LigaAnterior = nodoActual.LigaAnterior;
                            nuevoNodo.LigaSiguiente = nodoActual;
                            nodoActual.LigaAnterior.LigaSiguiente = nuevoNodo;
                            nodoActual.LigaAnterior = nuevoNodo;
                        }

                        return "Nodo insertado antes del dato X.";
                    }

                    nodoActual = nodoActual.LigaSiguiente;
                }

                // Si el dato específico no se encuentra en la lista, retornar un mensaje de error
                return $"El video no se encuentra en la lista.";
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: si ocurre un error, lanzar una excepción con el mensaje de error
                throw new Exception($"Error al insertar el nodo antes de '{datoX}': {ex.Message}");
            }
        }

        // Método para insertar un nuevo nodo en una posición específica de la lista
        public string InsertarEnPosicion(int posicion, string informacion)
        {
            try
            {
                // Verificar si la lista está vacía
                if (IsEmpty)
                {
                    return "La lista está vacía, no se puede realizar la inserción en una posición específica.";
                }

                // Crear un nuevo nodo con la información proporcionada
                var nuevoNodo = new Nodo(informacion);

                // Si la posición es 1, insertar el nuevo nodo al inicio de la lista
                if (posicion == 1)
                {
                    return AgregarNodoAlInicio(nuevoNodo);
                }

                // Inicializar el nodo actual como el primer nodo de la lista
                Nodo? nodoActual = PrimerNodo;
                // Inicializar un contador para rastrear la posición actual
                int contador = 1;

                // Recorrer la lista hasta encontrar la posición deseada o el final de la lista
                while (nodoActual != null && contador < posicion - 1)
                {
                    nodoActual = nodoActual.LigaSiguiente;
                    contador++;
                }

                // Si el nodo actual es nulo, significa que la posición está fuera de los límites de la lista
                if (nodoActual == null)
                {
                    return "La posición está fuera de los límites de la lista.";
                }

                // Si el nodo siguiente al actual es nulo, insertar el nuevo nodo al final de la lista
                if (nodoActual.LigaSiguiente == null)
                {
                    nodoActual.LigaSiguiente = nuevoNodo;
                    nuevoNodo.LigaAnterior = nodoActual;
                    UltimoNodo = nuevoNodo;
                    return $"Nodo insertado al final de la lista en la posición {posicion}.";
                }
                else
                {
                    // Insertar el nuevo nodo en la posición deseada
                    nuevoNodo.LigaSiguiente = nodoActual.LigaSiguiente;
                    nodoActual.LigaSiguiente.LigaAnterior = nuevoNodo;
                    nodoActual.LigaSiguiente = nuevoNodo;
                    nuevoNodo.LigaAnterior = nodoActual;
                    return $"Nodo insertado en la posición {posicion}.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: si ocurre un error, lanzar una excepción con el mensaje de error
                throw new Exception($"Error en la inserción en la posición {posicion}: {ex.Message}");
            }
        }

    }
}

