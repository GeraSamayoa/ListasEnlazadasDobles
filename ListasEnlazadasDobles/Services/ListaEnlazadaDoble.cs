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

        //Método para insertar un nodo al final de la lista

        public string InsertarNodoAlFinal(Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.LigaSiguiente = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }

            return "Se ha Insertado el nodo al final";
        }

        // Metodo para insertar un nodo antes de una posicion x
        public string InsertarNodoAntesPosicion(Nodo nuevoNodo, int posicion)
        {
            if (posicion <= 0)
            {
                return "La posición x debe ser un número mayor que cero";
            }

            // Se inicializan las variables auxiliares y el índice de posición
            Nodo? nodoActual = PrimerNodo;
            Nodo? nodoAnterior = null;
            int index = 2;

            // Recorre la lista hasta encontrar la posición x o hasta el final de la lista
            while (nodoActual != null && index < posicion)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.LigaAnterior; 
                index++; 
            }

            // Verifica si la posición x está fuera de rango
            if (nodoActual == null)
            {
                return "La posición x está fuera de rango";
            }

            // Inserta el nuevo nodo antes del nodo actual
            if (nodoAnterior != null)
            {
                nodoAnterior.LigaAnterior = nuevoNodo;
            }
            else
            {
                PrimerNodo = nuevoNodo;
            }

            nuevoNodo.LigaAnterior = nodoActual;

            // Retorna un mensaje indicando que se ha agregado el nodo antes de la posición x
            return $"Nodo agregado el nodo antes de la posición: {posicion}.";
        }

        // Método para Eliminar un nodo en una posición x
        public string EliminarNodoEnPosicion(int posicion)
        {
            // Verificar si la lista está vacía
            if (IsEmpty)
            {
                return "La lista está vacía";
            }

            // Verificar si la posición es inválida (menor o igual a cero)
            if (posicion <= 0)
            {
                return "La posición x debe ser un número positivo y mayor que cero";
            }

            // Inicializar variables para recorrer la lista
            Nodo? nodoActual = PrimerNodo;
            Nodo? nodoAnterior = null;
            int index = 1;

            // Recorrer la lista hasta encontrar la posición deseada o hasta el final de la lista.
            while (nodoActual != null && index < posicion)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.LigaAnterior;
                index++;
            }

            //  nodoActual == nulo , significa que la posición especificada está fuera de rango
            if (nodoActual == null)
            {
                return "La posición especificada está fuera de rango";
            }

            //  nodoAnterior !=  nulo, significa que no estamos eliminando el primer nodo
            if (nodoAnterior != null)
            {
                nodoAnterior.LigaAnterior = nodoActual.LigaSiguiente;
            }
            else
            {
                //  nodoAnterior == nulo, significa que estamos eliminando el primer nodo de la lista
                PrimerNodo = nodoActual.LigaSiguiente;
            }

            //  nodoActual es el último nodo de la lista, actualizar el último nodo
            if (nodoActual == UltimoNodo)
            {
                UltimoNodo = nodoAnterior;
            }

            return "¡Nodo eliminado correctamente!";
        }
    }
}
