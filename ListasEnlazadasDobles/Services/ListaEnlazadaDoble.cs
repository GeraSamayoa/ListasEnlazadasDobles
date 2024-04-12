using ListasEnlazadasDobles.Models;

namespace ListasEnlazadasDobles.Services
{
    // Clase ListaDoblementeEnlazada para manejar la lista
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

        // Método para insertar al final
        public string InsertarAlFinal(string Informacion)
        {
            Nodo nuevoNodo = new Nodo(Informacion);
            if (PrimerNodo == null)
            {
                PrimerNodo = nuevoNodo;
                UltimoNodo = nuevoNodo;

                return "lista Vacía";
            }
            else
            {
                UltimoNodo.LigaSiguiente = nuevoNodo;
                nuevoNodo.LigaAnterior = UltimoNodo;
                UltimoNodo = nuevoNodo;
            }
            return "Insertado correctamente al final";
        }

        // Método para insertar antes de una posición X
        public string InsertarAntesDe(string Informacion, int posicion)
        {
            Nodo nuevoNodo = new Nodo(Informacion);
            if (posicion <= 0)
            {

                return "Ingrese un valor mayor a 0";

            }

            if (PrimerNodo == null)
            {

                return " lista Vacía";
            }

            Nodo actual = PrimerNodo;
            int contador = 2;

            while (contador < posicion && actual.LigaSiguiente != null)
            {
                actual = actual.LigaSiguiente;
                contador++;
            }

            if (contador != posicion)
            {
                return "Pocision fuera de rango";
            }

            nuevoNodo.LigaSiguiente = actual;
            nuevoNodo.LigaAnterior = actual.LigaAnterior;

            if (actual.LigaAnterior != null)
            {
                actual.LigaAnterior.LigaSiguiente = nuevoNodo;
            }
            else
            {
                PrimerNodo = nuevoNodo;
            }

            actual.LigaAnterior = nuevoNodo;
            return "Nodo insertado correctamente";
        }

        // Método para eliminar en una posición X
        public string EliminarEn(int posicion)
        {
            if (posicion <= 0 || PrimerNodo == null)
            {
                return "Lista Vacía o ingrese una valor mayor a 0";
            }

            Nodo actual = PrimerNodo;
            int contador = 1;

            while (contador < posicion && actual.LigaSiguiente != null)
            {
                actual = actual.LigaSiguiente;
                contador++;
            }

            if (contador != posicion)
            {
                return "Posicion fuera de rango";
            }

            if (actual.LigaAnterior != null)
            {
                actual.LigaAnterior.LigaSiguiente = actual.LigaSiguiente;
            }
            else
            {
                PrimerNodo = actual.LigaSiguiente;
            }

            if (actual.LigaSiguiente != null)
            {
                actual.LigaSiguiente.LigaAnterior = actual.LigaAnterior;
            }
            else
            {
                UltimoNodo = actual.LigaAnterior;
            }
            return "nodo Eliminado correctamente";
        }

    }
}
