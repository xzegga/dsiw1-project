using System.Collections.Generic;
using System.ServiceModel;

namespace MiCafesito
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAllProduct();

        [OperationContract]
        Product GetProductById(int id);

        [OperationContract]
        void UpdateProduct(Product productos);

        [OperationContract]
        void DeleteProducto(int id);

        [OperationContract]
        void AddProduct(Product productos);
    }
}
