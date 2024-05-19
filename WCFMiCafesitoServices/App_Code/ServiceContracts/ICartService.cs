using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for ICartService
/// </summary>
/// 
namespace MiCafesito
{

    [ServiceContract]
    public interface ICartService
    {

        [OperationContract]
        void AddCartItem(Cart cart);

        [OperationContract]
        List<Cart> GetCartItemsByUserId(int id);

        [OperationContract]
        void UpdateCartItemById(int id, int quantity, double unitprice);

        [OperationContract]
        void DeleteCartItem(int id);

        [OperationContract]
        void DeleteCartItemsByUserId(int id);

    }
}