using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace tocatu.Models
{
    public class Bar : Usuario
    {
        [Required(ErrorMessage = "Debe ingresar una direccion")]
        public string Direccion { get; set; }
        //Obligatorio + msg error

        [Range(1, 5000, ErrorMessage = "Error de capacidad, ingrese una capacidad entre 1 y 5000")]
        public int Capacidad { get; set; }
        //Obligatorio + msg error + rangos > 0 
        public virtual ICollection<Evento> Eventos { get; set; }

    }
}


/*
 
 Range

The Range attributes specifies the minimum and maximum constrains for a numerical number, as shown below:
[Range(18, 30, ErrorMessage = "el mensaje")]  
public int Age  
{  
    get;  
    set;  
}

 
 */