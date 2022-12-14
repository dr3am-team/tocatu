using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace tocatu.Models
{
    public class Evento
    {
        //falta validar el desplegable que se rompe si no pones nada
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Debe ingresar un nombre del evento.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripcion del evento.")]
        public string Descripcion { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Error en el precio. Debe ingresar un precio mayor a 0.")]
        [Required(ErrorMessage = "Debe ingresar un precio.")]
        public double PrecioEntrada { get; set; }
        [Required(ErrorMessage = "Debe ingresar una fecha.")]
        public string Dia { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        
        public DateTime Fecha { get; set; }

        [Range(1, 24, ErrorMessage = "Error en la hora. Ingrese una hora valida.")]
        [Required(ErrorMessage = "Debe ingresar una hora.")]
        public string Hora { get; set; }
        public int Capacidad { get; set; }
        public string Direccion { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Titulo de imagen")]
        
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Subir imagen")]
        
        public IFormFile ImageFile { get; set; }
        public int? BarId { get; set; }
        public virtual Bar Bar { get; set; }
        public int? BandaId { get; set; }
        public virtual Banda Banda { get; set; }

        public string NombreBanda { get; set; }
        public string EstiloBanda { get; set; }
        /*
         Validaciones

        public int? BakeryId { get; set; }
    public virtual Bakery Bakery { get; set; }



         */

    }
}
