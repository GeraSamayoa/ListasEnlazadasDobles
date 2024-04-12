using System;
using System.Collections;
using System.Collections.Generic;

namespace Listas.Services
{
    // Clase Nodo que representa cada elemento de la lista enlazada.
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo? Siguiente { get; set; }

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    // Clase ListaEnlazadaSimple que gestiona la lista enlazada de nodos.
    public class ListaEnlazadaSimple : IEnumerable<Nodo>
    {
        public Nodo? PrimerNodo { get; private set; }
        public Nodo? UltimoNodo { get; private set; }

        public ListaEnlazadaSimple()
        {
            PrimerNodo = null;
            UltimoNodo = null;
        }

        // Verifica si la lista está vacía.
        public bool EstaVacia() => PrimerNodo == null;

        // Inserta un nuevo nodo al inicio de la lista.
        public void InsertarNodoAlInicio(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);
            if (EstaVacia())
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = PrimerNodo;
                PrimerNodo = nuevoNodo;
            }
        }

        // Elimina el nodo que se encuentra antes de la posición especificada.
        public void EliminarNodoAntesDe(int posicion)
        {
            if (EstaVacia())
            {
                throw new InvalidOperationException("No se puede eliminar un nodo de una lista vacía.");
            }

            if (posicion <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(posicion), "No existe un nodo antes de la primera posición.");
            }

            Nodo? nodoActual = PrimerNodo;
            Nodo? nodoAnteriorAlAnterior = null;

            // Iteramos hasta llegar al nodo anterior al que queremos eliminar.
            for (int i = 1; nodoActual != null && i < posicion - 1; i++)
            {
                nodoAnteriorAlAnterior = nodoActual;
                nodoActual = nodoActual.Siguiente;
            }

            if (nodoActual == null || nodoActual.Siguiente == null)
            {
                throw new ArgumentException("La posición es mayor que el número de nodos en la lista.");
            }

            // Eliminamos la referencia al nodo que queremos eliminar.
            nodoAnteriorAlAnterior.Siguiente = nodoActual.Siguiente;
        }

        // Elimina el nodo que se encuentra después de la posición especificada.
        public void EliminarNodoDespuesDe(int posicion)
        {
            if (EstaVacia())
            {
                throw new InvalidOperationException("No se puede eliminar un nodo de una lista vacía.");
            }

            Nodo? nodoActual = PrimerNodo;

            // Iteramos hasta llegar al nodo cuyo siguiente queremos eliminar.
            for (int i = 1; nodoActual != null && i < posicion; i++)
            {
                nodoActual = nodoActual.Siguiente;
            }

            if (nodoActual == null || nodoActual.Siguiente == null)
            {
                throw new ArgumentException("No hay nodo después de la posición dada o la posición es mayor que el número de nodos.");
            }

            // Si el nodo a eliminar es el último, actualizamos el puntero del último nodo.
            if (nodoActual.Siguiente == UltimoNodo)
            {
                UltimoNodo = nodoActual;
            }

            // Eliminamos la referencia al nodo que queremos eliminar.
            nodoActual.Siguiente = nodoActual.Siguiente.Siguiente;
        }

        // Implementación del método GetEnumerator requerido por la interfaz IEnumerable.
        public IEnumerator<Nodo> GetEnumerator()
        {
            Nodo? nodoActual = PrimerNodo;
            while (nodoActual != null)
            {
                yield return nodoActual;
                nodoActual = nodoActual.Siguiente;
            }
        }

        // Implementación explícita del método GetEnumerator no genérico.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
