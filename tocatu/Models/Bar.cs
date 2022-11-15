using System.Collections.Generic;

namespace tocatu.Models
{
  public class Bar : Usuario
  {
    public string Direccion { get; set; }
    //Obligatorio + msg error

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