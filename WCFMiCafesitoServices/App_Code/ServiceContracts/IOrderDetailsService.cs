using System.Collections.Generic;
using System.ServiceModel;

namespace MiCafesito
{
    [ServiceContract]
    public interface IOrderDetailsService
    {
        [OperationContract]
        List<OrderDetails> GetAllDetPedido();

        [OperationContract]
        void UpdateDetPedido(OrderDetails orderDetails);

        [OperationContract]
        void DeleteDetPedido(int id);

        [OperationContract]
        void AddDetPedido(OrderDetails orderDetails);
    }
}
