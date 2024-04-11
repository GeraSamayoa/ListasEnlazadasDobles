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
            NodoActual = NodoActual?.LigaSiguiente ?? UltimoNodo;
            return NodoActual;
        }

        public Nodo? Anterior()
        {
            NodoActual = NodoActual?.LigaAnterior ?? PrimerNodo;
            return NodoActual;
        }

        private bool ExisteDatoEnLista(string dato)
        {
            Nodo? nodoActual = PrimerNodo;

            // Recorrer la lista para buscar el dato
            while (nodoActual != null)
            {
                if (nodoActual.Informacion.Equals(dato))
                {
                    return true; // El dato ya existe en la lista
                }
                nodoActual = nodoActual.LigaSiguiente;
            }

            return false; // El dato no existe en la lista
        }


        public string AgregarAlInicio(string dato)
        {
            // Verificar si el dato ya existe en la lista
            if (ExisteDatoEnLista(dato))
            {
                return "El dato ya existe en la lista. No se pueden agregar datos duplicados.";
            }

            Nodo? nuevoNodo = new Nodo(dato);
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
            return "Nodo insertado";
        }

        public string InsertarDespuesDePosicionX(int posicion, string dato)
        {
            // Verificar si el dato ya existe en la lista
            if (ExisteDatoEnLista(dato))
            {
                return "El dato ya existe en la lista. No se pueden agregar datos duplicados.";
            }
            // Verificar si la posición es válida
            if (posicion <= 0)
            {
                return "La posición debe ser un número positivo mayor que cero.";
            }

            // Verificar si la lista está vacía y la posición es la primera
            if (EsListaVacia() && posicion == 1)
            {
                return " No se puede insertar en una lista vacía.";
            }

            Nodo? nuevoNodo = new Nodo(dato);
            Nodo? nodoActual = PrimerNodo;
            int contador = 1;
            bool posicionExcede = false; // Variable para detectar si la posición excede el tamaño de la lista

            // Iterar hasta la posición deseada o hasta el último nodo
            while (contador < posicion && nodoActual != null)
            {
                nodoActual = nodoActual.LigaSiguiente;
                contador++;
            }

            // Si la posición excede el número de nodos en la lista, setear la variable posicionExcede a true
            if (nodoActual == null)
            {
                posicionExcede = true;
            }

            // Si la posición excede, retornar un mensaje de error
            if (posicionExcede)
            {
                return "La posición especificada excede el número de nodos en la lista.";
            }

            // Insertar el nuevo nodo después de la posición especificada
            nuevoNodo.LigaSiguiente = nodoActual?.LigaSiguiente;
            if (nodoActual.LigaSiguiente != null)
            {
                nodoActual.LigaSiguiente.LigaAnterior = nuevoNodo;
            }
            nuevoNodo.LigaAnterior = nodoActual;
            nodoActual.LigaSiguiente = nuevoNodo;

            // Actualizar el último nodo si es necesario
            if (nodoActual == UltimoNodo)
            {
                UltimoNodo = nuevoNodo;
            }

            return "Nodo insertado después de la posición especificada.";
        }


        public string QuitarAlFinal()
        {
            //verifica si la lista está vacia, si es así, retorna un mensaje que nos indica que no hay elementos en la lista
            if (EsListaVacia())
            {
                return "No Existen Elementos";
            }
            // al contrario, si la lista no esta vacia, se verifica si Primer nodo es igual al ultimo nodo, si esto se cumple, se establece los nodos como nulos
            else if (PrimerNodo == UltimoNodo)
            {
                PrimerNodo = UltimoNodo = null;
            }
            //si no se ejecuta una de las condiciones anteriores, se ejecuta este bloque de codigo
            else
            {
                Nodo? nodoEliminar;//declaracion de la variable llamada nodoEliminar
                nodoEliminar = UltimoNodo;// se asigna el ultimo nodo a la variable nodo eliminar
                UltimoNodo = UltimoNodo?.LigaAnterior;//se actualiza el ultimo nodo para que apunte al nodo anterior
                UltimoNodo.LigaSiguiente = null;// establece el siguiente del ultimo nodo a null

                nodoEliminar = null;// libera la memoria del nodo eliminado
            }
            Nodos--;// disminuye el contador del total de los nodos
            return "nodo eliminado";// se retorna el mensaje de confirmación
        }
        
       public string EliminarAntesDeX(string datoX)
        {
            // Verificar si la lista está vacía
            if (EsListaVacia())
            {
                return "La lista está vacía.";
            }

            // Inicializar nodos
            Nodo? nodoActual = PrimerNodo; // Nodo actual que estamos revisando
            Nodo? nodoAnterior = null; // Nodo anterior al actual
            Nodo? nodoAEliminar = null; // Nodo que queremos eliminar

            // Buscar el nodo que contiene el dato x en la lista
            while (nodoActual != null && !nodoActual.Informacion.Equals(datoX))
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.LigaSiguiente; // Mover al siguiente nodo
            }

            // Si se encuentra el nodo con el dato x
            if (nodoActual != null)
            {
                // Si el nodo con el dato x es el primer nodo de la lista
                if (nodoActual == PrimerNodo)
                {
                    return "No se puede eliminar antes de " + datoX + " porque no hay un nodo anterior.";
                }
                else
                {
                    // Si el nodo con el dato x no es el segundo nodo
                    if (nodoAnterior != PrimerNodo)
                    {
                        // Establecer el nodo a eliminar
                        nodoAEliminar = nodoAnterior;
                        nodoAnterior = nodoAnterior?.LigaAnterior; // Mover al nodo anterior al nodo a eliminar

                        // Actualizar las ligas
                        nodoAnterior.LigaSiguiente = nodoActual;
                        nodoActual.LigaAnterior = nodoAnterior;

                        // Liberar el nodo
                        nodoAEliminar = null;

                        return "Nodo antes de " + datoX + " eliminado.";
                    }
                    else
                    {
                        // Si el nodo con el dato x es el segundo nodo
                        PrimerNodo = nodoActual; // El nodo actual se convierte en el primer nodo
                        nodoActual.LigaAnterior = null; // El nodo anterior al actual se establece como null
                        return "Nodo antes de " + datoX + " eliminado.";
                    }
                }
            }
            else
            {
                // Si no se encuentra el nodo que contiene el dato x
                return datoX + " no está presente en la lista.";
            }
        }



    }
}
