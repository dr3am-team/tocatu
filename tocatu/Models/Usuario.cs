using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tocatu.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Debe ingresar un nombre de usuario")]
        public string NombreUsuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe ingresar un mail valido")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}

/*
 * Validar todas como obligatorias y mensaje
 * https://www.c-sharpcorner.com/article/data-annotations-and-validation-in-mvc/
 */