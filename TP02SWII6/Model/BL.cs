using System.ComponentModel;

namespace TP02SWII6.Model
{
    
    // Gabriel Martins Alves da Silva - CB3021521  

    public class BL
    {
        public int ID { get; set; }
        public string Numero { get; set; }
        public string Consignee { get; set; }
        public string Navio { get; set; }
        public virtual ICollection<Container> Containers { get; set; }

    }
}
