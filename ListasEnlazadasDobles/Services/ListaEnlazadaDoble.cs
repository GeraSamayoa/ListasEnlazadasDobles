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

        public string AgregarAlInicio(string dato)
        {
            Nodo? nuevoNodo = new Nodo(dato);

            if (IsEmpty)
            {
                PrimerNodo = UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = PrimerNodo;
                PrimerNodo.LigaAnterior = nuevoNodo;
                PrimerNodo = nuevoNodo;

            }

            return "Nodo insertado con exito!";
        }

        public string EliminarUnDatoX(string dato)
        {
            Nodo? nodoActual;
            Nodo? nodoAuxiliarSiguiente;
            Nodo? nodoAuxiliarAnterior;

            if (IsEmpty){ return "La lista esta vacia";}

            nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual.Informacion == dato )
            {
                nodoActual = nodoActual.LigaSiguiente;
            }

            if(nodoActual == null)
            {
                return "Dato no encontrado";

            }else if (nodoActual.Informacion == dato)
            {
                nodoAuxiliarAnterior = nodoActual.LigaAnterior;
                nodoAuxiliarSiguiente = nodoActual.LigaSiguiente;

                nodoActual = null;
                nodoAuxiliarAnterior.LigaSiguiente = nodoAuxiliarSiguiente;
                nodoAuxiliarSiguiente.LigaAnterior = nodoAuxiliarAnterior;

            }

            return "Nodo eliminado con exito";

        }

    }
}
