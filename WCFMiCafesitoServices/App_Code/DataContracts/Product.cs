using System.Runtime.Serialization;

[DataContract]
public class Product
{

    [DataMember]
    public int ID_Producto { get; set; }

    [DataMember]
    public string Nombre { get; set; }

    [DataMember]
    public string Descripcion { get; set; }

    [DataMember]
    public double Precio { get; set; }

    [DataMember]
    public int ID_Categoria { get; set; }

    [DataMember]
    public string Categoria { get; set; }

    [DataMember]
    public string ImageUrl { get; set; }

}
