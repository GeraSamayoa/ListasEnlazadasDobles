namespace ListasEnlazadasDobles.Models
{
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
