using System.Collections.Generic;
using System.ServiceModel;

namespace MiCafesito
{
    [ServiceContract]
    public interface IProductosSevice
    {
        [OperationContract]
        List<Productos> GetAllProduct();

        [OperationContract]
        Productos GetProductById(int id);

        [OperationContract]
        void UpdateProduct(Productos productos);

        [OperationContract]
        void DeleteProducto(int id);

        [OperationContract]
        void AddProduct(Productos productos);
    }
}
