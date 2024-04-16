using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

[DataContract]
public class User
{
    [DataMember]
    public int ID_Usuario { get; set; }

    [DataMember]
    public string Nombre { get; set; }

    [DataMember]
    public string Apellido { get; set; }

    [DataMember]
    public DateTime Fecha_Nacimiento { get; set; }

    [DataMember]
    public string Email { get; set; }

    [DataMember]
    public string Password { get; set; }

    [DataMember]
    public string Telefono { get; set; }

    [DataMember]
    public string Estado { get; set; }

    [DataMember]
    public DateTime Fecha_Registro { get; set; }

    [DataMember]
    public int ID_Rol { get; set; }

    [DataMember]
    public string NombreRol { get; set; }
}