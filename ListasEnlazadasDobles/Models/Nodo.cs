namespace ListasEnlazadasDobles.Models
{
    // Clase Nodo para la lista doblemente enlazada
    public class Nodo
    {
        public Nodo? LigaAnterior { get; set; }

        public string Informacion { get; set; }

        public Nodo? LigaSiguiente { get; set; }

        public Nodo(string informacion)
        {
            LigaAnterior = null;
            Informacion = informacion;
            LigaSiguiente = null;
        }

    }
}
