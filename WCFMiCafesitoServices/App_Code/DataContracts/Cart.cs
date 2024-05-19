using System;
using System.Runtime.Serialization;

[DataContract]
public class Cart
{

    [DataMember]
    public int ID_Carrito { get; set; }

    [DataMember]
    public int ID_Usuario { get; set; }

    [DataMember]
    public int ID_Producto { get; set; }

    [DataMember]
    public double PrecioUnitario { get; set; }

    [DataMember]
    public int Cantidad { get; set; }
    [DataMember]

    public DateTime Fecha { get; set; }
}