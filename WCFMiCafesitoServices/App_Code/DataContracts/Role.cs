using System.Runtime.Serialization;


[DataContract]
public class Role
{
    [DataMember]
    public int ID_Rol { get; set; }

    [DataMember]
    public string Nombre { get; set; }
}