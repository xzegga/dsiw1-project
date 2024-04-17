using System;
using System.Runtime.Serialization;

[DataContract]
public class OrderDetails
{

    [DataMember]
    public int ID_Detalle { get; set; }

    [DataMember]
    public int ID_Pedido { get; set; }

    [DataMember]
    public int ID_Producto { get; set; }

    [DataMember]
    public int Cantidad { get; set; }

    [DataMember]
    public float PrecioUnitario { get; set; }

    [DataMember]
    public string Nombre { get; set; }

    [DataMember]
    public string Descripcion { get; set; }

    [DataMember]
    public float Precio { get; set; }

}

