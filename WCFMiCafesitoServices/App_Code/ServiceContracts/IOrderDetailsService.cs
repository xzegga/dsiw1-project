using System.Collections.Generic;
using System.ServiceModel;

namespace MiCafesito
{
    [ServiceContract]
    public interface IOrderDetailsService
    {
        [OperationContract]
        List<OrderDetail> GetAllOrderDetailByOrderId(int id);

        [OperationContract]
        void UpdateOrderDetail(OrderDetail orderDetails);

        [OperationContract]
        void DeleteOrderDetail(int id);

        [OperationContract]
        void AddOrderDetail(OrderDetail orderDetails);

        [OperationContract]
        void DeleteOrderDetailByOrderId(int id);
    }
}
