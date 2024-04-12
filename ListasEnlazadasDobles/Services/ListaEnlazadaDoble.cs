using ListasEnlazadasDobles.Models;
using System;

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

        // Método para insertar un nodo al inicio de la lista
        public void InsertarNodoAlInicio(Nodo nuevoNodo)
        {
            if (nuevoNodo == null)
            {
                throw new ArgumentNullException(nameof(nuevoNodo), "El nodo a insertar no puede ser nulo.");
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
        }

        // Método para eliminar un nodo antes de una posición dada
        public void EliminarNodoAntesDe(int posicion)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No se puede eliminar un nodo de una lista vacía.");
            }
            if (posicion <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(posicion), "La posición debe ser mayor que 1.");
            }

            Nodo nodoAnterior = PrimerNodo;
            for (int i = 1; i < posicion && nodoAnterior.LigaSiguiente != null; i++)
            {
                nodoAnterior = nodoAnterior.LigaSiguiente;
            }

            if (nodoAnterior != null && nodoAnterior.LigaAnterior != null)
            {
                Nodo nodoAEliminar = nodoAnterior.LigaAnterior;
                nodoAnterior.LigaAnterior = nodoAEliminar.LigaAnterior;
                if (nodoAEliminar.LigaAnterior != null)
                {
                    nodoAEliminar.LigaAnterior.LigaSiguiente = nodoAnterior;
                }
                else
                {
                    PrimerNodo = nodoAnterior;
                }
            }
        }

        // Método para eliminar un nodo después de una posición dada
        public void EliminarNodoDespuesDe(int posicion)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No se puede eliminar un nodo de una lista vacía.");
            }
            if (posicion < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(posicion), "La posición no puede ser negativa.");
            }

            Nodo nodoAnterior = PrimerNodo;
            for (int i = 1; i < posicion && nodoAnterior != null; i++)
            {
                nodoAnterior = nodoAnterior.LigaSiguiente;
            }

            if (nodoAnterior != null && nodoAnterior.LigaSiguiente != null)
            {
                Nodo nodoAEliminar = nodoAnterior.LigaSiguiente;
                nodoAnterior.LigaSiguiente = nodoAEliminar.LigaSiguiente;
                if (nodoAEliminar.LigaSiguiente != null)
                {
                    nodoAEliminar.LigaSiguiente.LigaAnterior = nodoAnterior;
                }
                else
                {
                    UltimoNodo = nodoAnterior;
                }
            }
        }

        // Método para moverse al siguiente nodo de la lista
        public Nodo Siguiente()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No se puede mover al siguiente nodo en una lista vacía.");
            }
            if (NodoActual == null)
            {
                throw new InvalidOperationException("NodoActual no está establecido.");
            }

            NodoActual = NodoActual.LigaSiguiente ?? UltimoNodo;
            return NodoActual;
        }

        // Método para moverse al nodo anterior de la lista
        public Nodo Anterior()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No se puede mover al nodo anterior en una lista vacía.");
            }
            if (NodoActual == null)
            {
                throw new InvalidOperationException("NodoActual no está establecido.");
            }

            NodoActual = NodoActual.LigaAnterior ?? PrimerNodo;
            return NodoActual;
        }
    }
}
