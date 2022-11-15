using System.Collections.Generic;

namespace tocatu.Models
{
    public class Banda: Usuario
    {
        public string Estilo { get; set; }
    public virtual ICollection<Evento> Eventos { get; set; }
    //Obligatorio + msg error
  }
}
