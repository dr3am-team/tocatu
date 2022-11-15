using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tocatu.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}

/*
 * Validar todas como obligatorias y mensaje
 * https://www.c-sharpcorner.com/article/data-annotations-and-validation-in-mvc/
 */