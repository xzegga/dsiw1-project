using System.Collections.Generic;
using System.ServiceModel;

namespace MiCafesito
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAllProducts();

        [OperationContract]
        Product GetProductById(int id);

        [OperationContract]
        void UpdateProduct(Product productos);

        [OperationContract]
        void DeleteProduct(int id);

        [OperationContract]
        void AddProduct(Product productos);

        [OperationContract]
        List<Product> GetAllProductsByCategoryId(int id);

        [OperationContract]
        List<Product> GetProductsFeatured();

        [OperationContract]
        List<Product> GetProductsByName(string criteria);
    }
}
