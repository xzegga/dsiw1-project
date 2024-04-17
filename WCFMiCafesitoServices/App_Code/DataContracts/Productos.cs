
using System;
using System.Runtime.Serialization;

[DataContract]
public class Category
{

    [DataMember]
    public int ID_Producto { get; set; }

    [DataMember]
    public string Nombre { get; set; }

    [DataMember]
    public string Descripcion { get; set; }

    [DataMember]
    public string Precio { get; set; }

    [DataMember]
    public string ID_Categoria { get; set; }

}
