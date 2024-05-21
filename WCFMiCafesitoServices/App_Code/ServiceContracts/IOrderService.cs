using System.Collections.Generic;
using System.ServiceModel;
namespace MiCafesito
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        List<Order> GetAllOrders();

        [OperationContract]
        Order GetOrderById(int id);

        [OperationContract]
        void UpdateOrder(Order order);

        [OperationContract]
        void DeleteOrder(int id);

        [OperationContract]
        int AddOrder(Order order);

        [OperationContract]
        List<Order> GetAllOrdersByUserId(int id);
    }
}