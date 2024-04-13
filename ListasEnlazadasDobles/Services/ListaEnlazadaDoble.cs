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
        }

        public bool IsEmpty => PrimerNodo == null;

        public bool EsListaVacia()
        {
            return PrimerNodo == null;
        }
        private bool ExisteDatoEnLista(string dato)
        {
            Nodo? nodoActual = PrimerNodo;

            // Recorrer la lista para buscar el dato
            while (nodoActual != null)
            {
                if (nodoActual.Nombre.Equals(dato))
                {
                    return true; // El dato ya existe en la lista
                }
                nodoActual = nodoActual.LigaSiguiente;
            }

            return false; // El dato no existe en la lista
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

        // Método para insertar un nodo al final de la lista
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

            return "Nodo agregado al final";
        }

        // Método para insertar un nodo al inicio de la lista
        public string InsertarNodoAlInicio(Nodo nuevoNodo)
        {
            if (nuevoNodo == null)
            {
                return "El nodo a insertar no puede ser nulo.";
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

            return "Nodo agregado el nodo al inicio";
        }

        // Método para eliminar un nodo antes de una posición dada
        public string EliminarNodoAntesDe(int posicion)
        {
            if (IsEmpty)
            {
                return "No se puede eliminar un nodo de una lista vacía.";
            }
            if (posicion <= 1)
            {
                return "La posición debe ser mayor que 1.";
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
            return "¡Se ha eliminado el nodo antes de la posición dada!.";
        }

        // Método para eliminar un nodo después de una posición dada
        public string EliminarNodoDespuesDe(int posicion)
        {
            if (IsEmpty)
            {
                return "No se puede eliminar un nodo de una lista vacía.";
            }
            if (posicion < 0)
            {
                return "La posición no puede ser negativa.";
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

            return "¡Se ha eliminado el nodo después de la posición dada!";
        }

        // Método para insertar antes de una posición X
        public string InsertarAntesDe(string Informacion, string Nombre, int posicion)
        {
            Nodo nuevoNodo = new Nodo(Informacion, Nombre);
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
            return "Nodo agregado correctamente";
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
            return "¡Se ha eliminado el nodo correctamente!";
        }


        //////////////////////////////////////////////////////////////////////////
        public string InsertarDespuesDePosicionX(int posicion, string dato, string nombre)
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

            Nodo? nuevoNodo = new Nodo(dato, nombre);
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

            return $"Nodo agregado después de la posición especificada.";
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
            return "Se ha eliminado el correctamente";// se retorna el mensaje de confirmación
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
            while (nodoActual != null && !nodoActual.Nombre.Equals(datoX))
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

                        return "¡Se ha eliminado el nodo antes de " + datoX + " eliminado.";
                    }
                    else
                    {
                        // Si el nodo con el dato x es el segundo nodo
                        PrimerNodo = nodoActual; // El nodo actual se convierte en el primer nodo
                        nodoActual.LigaAnterior = null; // El nodo anterior al actual se establece como null
                        return "¡Se ha eliminado Nodo antes de " + datoX + " eliminado.";
                    }
                }
            }
            else
            {
                // Si no se encuentra el nodo que contiene el dato x
                return datoX + " no está presente en la lista.";
            }
        }


        ///////////////////////////////////////////////////////////////////////////
        public string EliminarNodoInicio()
        {
            try
            {
                // Verificar si la lista está vacía
                if (IsEmpty)
                {
                    return "La lista de videos está vacía.";
                }
                else
                {
                    // Si la lista contiene solo un nodo
                    if (PrimerNodo == UltimoNodo)
                    {
                        PrimerNodo = UltimoNodo = null;
                    }
                    else
                    {
                        // Si la lista contiene más de un nodo
                        Nodo temp = PrimerNodo;
                        PrimerNodo = PrimerNodo.LigaSiguiente;
                        if (PrimerNodo != null)
                        {
                            PrimerNodo.LigaAnterior = null;
                        }
                        temp = null;
                    }

                    return "¡Se ha eliminado el nodo al inicio correctamente";
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: si ocurre un error, lanzar una excepción con el mensaje de error
                throw new Exception($"Error al eliminar el nodo al inicio: {ex.Message}");
            }
        }

        // Método para insertar un nuevo nodo antes de un dato específico en la lista
        public string InsertarAntesDeUnDatoX(string datoX, Nodo nuevoNodo)
        {
            try
            {
                // Verificar si la lista está vacía
                if (IsEmpty)
                {
                    return "La lista está vacía, no se puede insertar el nodo.";
                }

                Nodo nodoActual = PrimerNodo;
                // Recorrer la lista
                while (nodoActual != null)
                {
                    // Verificar si se ha encontrado el dato específico
                    if (nodoActual.Nombre == datoX)
                    {
                        // Insertar el nuevo nodo antes del dato específico
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

                        return "Se ha agregado el nodo antes del dato X.";
                    }

                    nodoActual = nodoActual.LigaSiguiente;
                }

                // Si el dato específico no se encuentra en la lista, retornar un mensaje de error
                return $"El video no se encuentra en la lista.";
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: si ocurre un error, lanzar una excepción con el mensaje de error
                throw new Exception($"Error al insertar el nodo antes de '{datoX}': {ex.Message}");
            }
        }

        // Método para insertar un nuevo nodo en una posición específica de la lista
        public string InsertarEnPosicion(int posicion, string informacion, string nombre)
        {
            try
            {
                // Verificar si la lista está vacía
                if (IsEmpty)
                {
                    return "La lista está vacía, no se puede realizar la inserción en una posición específica.";
                }

                // Crear un nuevo nodo con la información proporcionada
                var nuevoNodo = new Nodo(informacion, nombre);

                // Si la posición es 1, insertar el nuevo nodo al inicio de la lista
                if (posicion == 1)
                {
                    return InsertarNodoAlInicio(nuevoNodo);
                }

                // Inicializar el nodo actual como el primer nodo de la lista
                Nodo? nodoActual = PrimerNodo;
                // Inicializar un contador para rastrear la posición actual
                int contador = 1;

                // Recorrer la lista hasta encontrar la posición deseada o el final de la lista
                while (nodoActual != null && contador < posicion - 1)
                {
                    nodoActual = nodoActual.LigaSiguiente;
                    contador++;
                }

                // Si el nodo actual es nulo, significa que la posición está fuera de los límites de la lista
                if (nodoActual == null)
                {
                    return "La posición está fuera de los límites de la lista.";
                }

                // Si el nodo siguiente al actual es nulo, insertar el nuevo nodo al final de la lista
                if (nodoActual.LigaSiguiente == null)
                {
                    nodoActual.LigaSiguiente = nuevoNodo;
                    nuevoNodo.LigaAnterior = nodoActual;
                    UltimoNodo = nuevoNodo;
                    return $"Se agregado el nodo al final de la lista en la posición {posicion}.";
                }
                else
                {
                    // Insertar el nuevo nodo en la posición deseada
                    nuevoNodo.LigaSiguiente = nodoActual.LigaSiguiente;
                    nodoActual.LigaSiguiente.LigaAnterior = nuevoNodo;
                    nodoActual.LigaSiguiente = nuevoNodo;
                    nuevoNodo.LigaAnterior = nodoActual;
                    return $"Se ha agregado el nodo en la posición {posicion}.";
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: si ocurre un error, lanzar una excepción con el mensaje de error
                throw new Exception($"Error en la inserción en la posición {posicion}: {ex.Message}");
            }
        }

        ///////////////////////////////////////////////////////////////////////////

        // Metodo para insertar un nodo despues de un dato especifico string
        public string InsertarDespuesDeUnDatoX(string dato, Nodo nuevoNodo)
        {
            if (IsEmpty)
            {
                return "La lista esta vacia";
            }

            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual.Nombre != dato)
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

            return "Se ha agregado el nodo despues de " + dato;
        }

        public string EliminarNodoPorContenido(string dato)
        {
            if (IsEmpty)
            {
                return "La lista está vacía.";
            }

            Nodo? nodoActual = PrimerNodo;
            Nodo? nodoAnterior = null;

            while (nodoActual != null && nodoActual.Nombre != dato)
            {
                nodoAnterior = nodoActual;
                nodoActual = nodoActual.LigaSiguiente;
            }

            if (nodoActual == null)
            {
                return "El dato no se encuentra en la lista.";
            }

            if (nodoAnterior == null)
            {
                // El nodo a eliminar es el primer nodo
                PrimerNodo = nodoActual.LigaSiguiente;
                if (PrimerNodo != null)
                {
                    PrimerNodo.LigaAnterior = null;
                }
                else
                {
                    UltimoNodo = null;
                }
            }
            else
            {
                nodoAnterior.LigaSiguiente = nodoActual.LigaSiguiente;
                if (nodoActual.LigaSiguiente != null)
                {
                    nodoActual.LigaSiguiente.LigaAnterior = nodoAnterior;
                }
                else
                {
                    UltimoNodo = nodoAnterior;
                }
            }

            nodoActual = null;

            return "Se ha eliminado el nodo con el dato " + dato;
        }

        public string EliminarNodoDespuesDeContenido(string dato)
        {
            if (IsEmpty)
            {
                return "La lista está vacía.";
            }

            Nodo? nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual.Nombre != dato)
            {
                nodoActual = nodoActual.LigaSiguiente;
            }

            if (nodoActual == null)
            {
                return "El dato no se encuentra en la lista.";
            }

            if (nodoActual == UltimoNodo)
            {
                return "No hay un nodo después del último nodo.";
            }

            Nodo? nodoEliminar = nodoActual.LigaSiguiente;

            nodoActual.LigaSiguiente = nodoEliminar.LigaSiguiente;

            if (nodoEliminar == UltimoNodo)
            {
                UltimoNodo = nodoActual;
            }
            else
            {
                nodoEliminar.LigaSiguiente.LigaAnterior = nodoActual;
            }

            nodoEliminar = null;

            return "Se ha eliminado el nodo después del nodo con el dato " + dato;
        }

        public Nodo? BuscarNodo(string dato)
        {
            if (IsEmpty)
            {
                return null;
            }

            Nodo? nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual.Nombre != dato)
            {
                nodoActual = nodoActual.LigaSiguiente;
            }

            return nodoActual;
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


        // Metodo para ordenar la lista en orden alfabético
        public string OrdenarLista()
        {
            if (IsEmpty)
            {
                return "La lista esta vacia";
            }

            Nodo nodoActual = PrimerNodo;
            Nodo nodoSiguiente = null;
            string tempNombre;
            string tempInformacion;

            while (nodoActual != null)
            {
                nodoSiguiente = nodoActual.LigaSiguiente;

                while (nodoSiguiente != null)
                {
                    if (string.Compare(nodoActual.Nombre, nodoSiguiente.Nombre) > 0)
                    {
                        tempNombre = nodoActual.Nombre;
                        tempInformacion = nodoActual.Informacion;

                        nodoActual.Nombre = nodoSiguiente.Nombre;
                        nodoActual.Informacion = nodoSiguiente.Informacion;

                        nodoSiguiente.Nombre = tempNombre;
                        nodoSiguiente.Informacion = tempInformacion;
                    }

                    nodoSiguiente = nodoSiguiente.LigaSiguiente;
                }

                nodoActual = nodoActual.LigaSiguiente;
            }

            return "Lista ordenada correctamente";
        }

        public int ObtenerPosicionNodo(Nodo? nodo)
        {
            if (nodo == null)
            {
                return -1;
            }

            int index = 1;
            Nodo? nodoActual = PrimerNodo;

            while (nodoActual != null && nodoActual != nodo)
            {
                nodoActual = nodoActual.LigaSiguiente;
                index++;
            }

            return nodoActual == nodo ? index : -1;
        }


    }
}