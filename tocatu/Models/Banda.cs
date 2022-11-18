using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tocatu.Models
{
  public class Banda : Usuario
  {
        [Required(ErrorMessage = "Debe ingresar un estilo")]
        public string Estilo { get; set; }
    public virtual ICollection<Evento> Eventos { get; set; }
    //Obligatorio + msg error
  }
}
