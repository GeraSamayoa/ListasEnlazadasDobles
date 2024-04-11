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

        // Metodo para insertar un nodo despues de un dato especifico string
        public string InsertarDespuesDeUnDatoX(string dato, Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                return "La lista esta vacia";
            }

            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual.Informacion != dato)
            {
                nodoActual = nodoActual.LigaSiguiente;
            }

            if (nodoActual == null)
            {
                return "Dato no encontrado";
            }

            if (nodoActual == UltimoNodo)
            {
                nuevoNodo.LigaAnterior = UltimoNodo;
                UltimoNodo.LigaSiguiente = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = nodoActual.LigaSiguiente;
                nodoActual.LigaSiguiente.LigaAnterior = nuevoNodo;
                nodoActual.LigaSiguiente = nuevoNodo;
                nuevoNodo.LigaAnterior = nodoActual;
            }

            NodoActual = nuevoNodo;

            return "Nodo insertado despues de " + dato;
        }

        // Metodo para buscar un nodo por su informacion en una lista doblemente enlazada
        public string BuscarNodo(string dato)
        {
            if (IsEmpty)
            {
                return "Lista vacia no hay elementos para buscar";
            }

            int index = 1;
            Nodo? nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual.Informacion != dato)
            {
                nodoActual = nodoActual.LigaSiguiente;
                index++;
            }

            if (nodoActual == null)
            {
                return $"Dato {dato} no encontrado";
            }

            return $"Nodo encontrado: {nodoActual.Informacion} en posicion {index}";
        }

        // Metodo para recorrer la lista recursivamente
        public static void RecorrerRecursivamente(Nodo? nodoActual, List<Nodo> nodos)
        {
            if (nodoActual != null)
            {
                nodos.Add(nodoActual); // Agregar el nodo a la lista
                RecorrerRecursivamente(nodoActual.LigaSiguiente, nodos); 
            }
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

    }
}
