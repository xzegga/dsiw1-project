
using System;
using System.Runtime.Serialization;

[DataContract]
public class Order
{
    [DataMember]
    public int ID_Pedido { get; set; }

    [DataMember]
    public int ID_Usuario { get; set; }

    [DataMember]
    public DateTime FechaPedido { get; set; }

    [DataMember]
    public string Estado { get; set; }

    [DataMember]
    public string Factura { get; set; }

    [DataMember]
    public double SubTotal { get; set; }
}