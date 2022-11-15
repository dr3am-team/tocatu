using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tocatu.Models
{
  public class Evento
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EventId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public double PrecioEntrada { get; set; }
    public string Dia { get; set; }
    public string Hora { get; set; }
    public int Capacidad { get; set; }
    public string Direccion { get; set; }
    public int? BarId { get; set; }
    public virtual Bar Bar { get; set; }
    //Objeto Bar

    public int? BandaId { get; set; }
    public virtual Banda Banda { get; set; }
    //Objeto Banda

    /*
     Validaciones

    public int? BakeryId { get; set; }
        public virtual Bakery Bakery { get; set; }



     */

  }
}
