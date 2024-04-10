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
            if (IsEmpty)

            {
                return "La lista de videos esta vacía ";
            }
            else
            {
                if (PrimerNodo == UltimoNodo)
                {
                    PrimerNodo = UltimoNodo = null;
                }
                else
                {
                    Nodo temp = PrimerNodo;
                    PrimerNodo = PrimerNodo.LigaSiguiente;
                    PrimerNodo.LigaAnterior = null;
                    temp = null;
                }
                
                return "VIDEO ELIMINADO AL INICIO";
            }
        }
        public string InsertAntesDeX (string datoX, Nodo nuevoNodo)
        {
           
                if (IsEmpty)
                {
                    return "La lista está vacía, no se puede insertar el nodo.";
                }

                Nodo nodoActual = PrimerNodo;
                while (nodoActual != null)
                {
                    if (nodoActual.Informacion == datoX)
                    {
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

                return $"El video '{datoX}' no se encuentra en la lista.";
        }
    }
}

