namespace TP02SWII6.Model
{
    
    // Gabriel Martins Alves da Silva - CB3021521
    
    public class Container
    {
        public int ID { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int Tamanho { get; set; }
        public int BLID { get; set; }
        public virtual BL BL { get; set; }
    }

}
