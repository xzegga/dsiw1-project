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
        void UpdateProduct(Product product);

        [OperationContract]
        void DeleteProduct(int id);

        [OperationContract]
        int AddProduct(Product product);

        [OperationContract]
        List<Product> GetAllProductsByCategoryId(int id);

        [OperationContract]
        List<Product> GetProductsFeatured();

        [OperationContract]
        List<Product> GetProductsByName(string criteria);
    }
}
