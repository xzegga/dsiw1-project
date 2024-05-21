using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WAMiCafesitoApp.Helpers;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp.Services
{
    public class CartService
    {
        private ICartService _cartService = new CartServiceClient();
        private readonly Auth _auth = new Auth();

        public List<Cart> AddOrUpdateCartItem(Product product, int quantity)
        {
            int userId = _auth.isAuthenticatedOrRedirect();
            if (!userId.Equals(0))
            {
                List<Cart> cartItems = _cartService.GetCartItemsByUserId(userId).ToList();

                Cart cartItem = cartItems.FirstOrDefault(item => item.ID_Producto == product.ID_Producto);

                if (cartItem == null)
                {
                    Cart cart = new Cart
                    {
                        ID_Usuario = userId,
                        ID_Producto = product.ID_Producto,
                        Cantidad = quantity,
                        PrecioUnitario = product.Precio,
                        Fecha = DateTime.Now
                    };

                    _cartService.AddCartItem(cart);
                }
                else
                {
                    _cartService.UpdateCartItemById(cartItem.ID_Carrito, cartItem.Cantidad + quantity, cartItem.PrecioUnitario);
                }
            }

            return GetCartItems();
        }

        public void UpdateCartItemQuantity(int id, int quantity)
        {
            int userId = _auth.isAuthenticatedOrRedirect();
            if (!userId.Equals(0))
            {
                _cartService.UpdateCartItemQuantityById(id, quantity);
            }
        }

        public List<Cart> GetCartItems()
        {
            List<Cart> cartItems = new List<Cart>();
            int userId = _auth.isAuthenticated();
            if (!userId.Equals(0))
            {
                cartItems = _cartService.GetCartItemsByUserId(userId).ToList();
                return cartItems;
            }

            return cartItems;
        }

        public void DeleteCartItem(int id)
        {
            int userId = _auth.isAuthenticated();
            if (!userId.Equals(0))
            {
                _cartService.DeleteCartItem(id);
            }
        }

        public void ClearCart()
        {
            int userId = _auth.isAuthenticated();
            if (!userId.Equals(0))
            {
                _cartService.DeleteCartItemsByUserId(userId);
            }
        }
    }

}