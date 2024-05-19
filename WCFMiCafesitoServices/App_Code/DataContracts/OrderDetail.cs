using System.Runtime.Serialization;

[DataContract]
public class OrderDetail
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
    public float Total { get; set; }

}

