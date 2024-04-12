using System;
using System.Collections;
using System.Collections.Generic;

namespace Listas.Services
{
    // Clase Nodo que representa cada elemento de la lista enlazada.
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    // Clase ListaEnlazadaSimple que gestiona la lista enlazada de nodos.
    public class ListaEnlazadaSimple : IEnumerable<Nodo>
    {
        public Nodo PrimerNodo { get; private set; }
        public Nodo UltimoNodo { get; private set; }

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

        // Solicita al usuario ingresar la posición y elimina el nodo antes de esa posición.
        public void EliminarNodoAntesDe()
        {
            Console.WriteLine("Ingrese la posición antes de la cual desea eliminar el nodo:");
            if (!int.TryParse(Console.ReadLine(), out int posicion) || posicion <= 1)
            {
                Console.WriteLine("Posición inválida. Debe ser un número entero mayor que 1.");
                return;
            }

            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnteriorAlAnterior = null;

            for (int i = 1; nodoActual != null && i < posicion - 1; i++)
            {
                nodoAnteriorAlAnterior = nodoActual;
                nodoActual = nodoActual.Siguiente;
            }

            if (nodoAnteriorAlAnterior == null || nodoActual == null || nodoActual.Siguiente == null)
            {
                Console.WriteLine("No se encontró un nodo antes de la posición especificada.");
                return;
            }

            nodoAnteriorAlAnterior.Siguiente = nodoActual.Siguiente;
        }

        // Solicita al usuario ingresar la posición y elimina el nodo después de esa posición.
        public void EliminarNodoDespuesDe()
        {
            Console.WriteLine("Ingrese la posición después de la cual desea eliminar el nodo:");
            if (!int.TryParse(Console.ReadLine(), out int posicion))
            {
                Console.WriteLine("Posición inválida. Debe ser un número entero.");
                return;
            }

            if (EstaVacia())
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo nodoActual = PrimerNodo;

            for (int i = 1; nodoActual != null && i < posicion; i++)
            {
                nodoActual = nodoActual.Siguiente;
            }

            if (nodoActual == null || nodoActual.Siguiente == null)
            {
                Console.WriteLine("No hay nodo después de la posición dada o la posición es mayor que el número de nodos.");
                return;
            }

            nodoActual.Siguiente = nodoActual.Siguiente.Siguiente;
        }

        // Implementación del método GetEnumerator requerido por la interfaz IEnumerable.
        public IEnumerator<Nodo> GetEnumerator()
        {
            Nodo nodoActual = PrimerNodo;
            while (nodoActual != null)
            {
                yield return nodoActual;
                nodoActual = nodoActual.Siguiente;
            }
        }

        // Implementación requerida por la interfaz IEnumerable.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
