using System;
using System.Runtime.Serialization;

[DataContract]
public class DetalleService
{

    [DataMember]
    public int ID_Detalle { get; set; }

    [DataMember]
    public string ID_Pedido { get; set; }

    [DataMember]
    public string ID_Producto { get; set; }

    [DataMember]
    public string Cantidad { get; set; }

    [DataMember]
    public string PrecioUnitario { get; set; }

    [DataMember]
    public string Nombre { get; set; }

    [DataMember]
    public string Descripcion { get; set; }

    [DataMember]
    public string Precio { get; set; }

}

