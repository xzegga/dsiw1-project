using System.Runtime.Serialization;

[DataContract]
public class Category
{

    [DataMember]
    public int ID_Categoria { get; set; }

    [DataMember]
    public string Nombre { get; set; }

    [DataMember]
    public string Descripcion { get; set; }
}