namespace ListasEnlazadasDobles.Models
{
    public class Nodo
    {
        public Nodo? LigaAnterior { get; set; }
        public string Informacion { get; set; }
        public Nodo? LigaSiguiente { get; set; }
        public string Nombre { get; set; }
        public Nodo(string informacion, string nombre)
        {
            LigaAnterior = null;
            Informacion = informacion;
            Nombre = nombre;
            LigaSiguiente = null;
        }

    }
}
