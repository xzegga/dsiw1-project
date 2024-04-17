using System.Collections.Generic;
using System.ServiceModel;

namespace MiCafesito
{
    [ServiceContract]
    public interface IProductDetailService
    {
        [OperationContract]
        List<ProductDetailService> GetAllDetPedido();

        [OperationContract]
        void UpdateDetPedido(DetallePedido Detallepedido);

        [OperationContract]
        void DeleteDetPedido(int id);

        [OperationContract]
        void AddDetPedido(DetallePedido Detallepedido);
    }
}
