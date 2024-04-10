using ListasEnlazadasDobles.Models;

namespace ListasEnlazadasDobles.Services
{
    public class ListaEnlazadaDoble
    {
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }
        public int Nodos { get; set; } 

        public Nodo? NodoActual { get; set; }
        public ListaEnlazadaDoble()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            NodoActual = null;
            Nodos = 0;
        }
        public bool IsEmpty => PrimerNodo == null;


        public bool EsListaVacia() 
        {
            return PrimerNodo == null;
        }

        public Nodo? Siguiente()
        {
            NodoActual = NodoActual.LigaSiguiente ?? UltimoNodo;
            return NodoActual;
        }

        public Nodo? Anterior()
        {
            NodoActual = NodoActual.LigaAnterior ?? PrimerNodo;
            return NodoActual;
        }



        public string AgregarAlInicio(string dato) 
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (EsListaVacia())
            {
                PrimerNodo = UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.LigaSiguiente = PrimerNodo;
                PrimerNodo.LigaAnterior = nuevoNodo;
                PrimerNodo = nuevoNodo;
            }
            Nodos++;
            return "nodo insertado";

        }
        public string InsertarDespuesDePosicionX(int posicion, string dato)
        {
            Nodo nuevoNodo = new Nodo(dato);

            if (posicion <= 0)
            {
                return "La posición debe ser un número positivo mayor que cero.";
            }

            Nodo? nodoActual = PrimerNodo;
            int contador = 1;

            while (contador < posicion && nodoActual != null)
            {
                nodoActual = nodoActual.LigaSiguiente;
                contador++;
            }

            if (nodoActual == null)
            {
                return "La posición especificada no existe en la lista.";
            }

            nuevoNodo.LigaSiguiente = nodoActual.LigaSiguiente;
            if (nodoActual.LigaSiguiente != null)
            {
                nodoActual.LigaSiguiente.LigaAnterior = nuevoNodo;
            }
            nuevoNodo.LigaAnterior = nodoActual;
            nodoActual.LigaSiguiente = nuevoNodo;

            if (nodoActual == UltimoNodo)
            {
                UltimoNodo = nuevoNodo;
            }

            return "Nodo insertado después de la posición especificada.";
        }

        public string QuitarAlFinal()
        {
            if (EsListaVacia())
            {
                return "No Existen Elementos";
            }
            else if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            else
            {
                Nodo? nodoEliminar;
                nodoEliminar = UltimoNodo;
                UltimoNodo = UltimoNodo.LigaAnterior;
                UltimoNodo.LigaSiguiente = null;

                nodoEliminar = null;
            }
            Nodos--;
            return "nodo eliminado";
        }
        public string EliminarNodoConDatoX(object datoX)
        {
          
            if (EsListaVacia())
            {
                return "La lista está vacía.";
            }

            Nodo nodoActual = PrimerNodo;
            Nodo nodoAnterior = null;

            
            while (nodoActual != null && !nodoActual.Informacion.Equals(datoX))
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.LigaSiguiente;
            }

        
            if (nodoActual != null)
            {
           
                if (PrimerNodo == UltimoNodo)
                {
                    PrimerNodo = UltimoNodo = null;
                }
                else
                {
                    
                    if (nodoAnterior != null)
                    {
                        
                        Nodo nodoTemporal = nodoAnterior;

                      
                        nodoAnterior.LigaSiguiente = nodoActual.LigaSiguiente;

                   
                        nodoActual.LigaAnterior = null;

                      
                        nodoTemporal = null;
                    }
                }

                
                return "Nodo con el dato especificado eliminado.";
            }
            else
            {
             
                return "El dato especificado no se encontró en la lista.";
            }
        }

    }
}
