using System.Collections.Generic;
using System.ServiceModel;

namespace MiCafesito
{
    [ServiceContract]
    public interface IOrderDetailsService
    {
        [OperationContract]
        List<OrderDetails> GetAllOrderDetail();

        [OperationContract]
        void UpdateOrderDetail(OrderDetails orderDetails);

        [OperationContract]
        void DeleteOrderDetail(int id);

        [OperationContract]
        void AddOrderDetail(OrderDetails orderDetails);
    }
}
