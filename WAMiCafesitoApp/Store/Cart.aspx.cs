using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.ServiceApi;
using WAMiCafesitoApp.Services;

namespace WAMiCafesitoApp.Store
{
    public partial class ShoppingCart : System.Web.UI.Page
    {

        private CartService _cartService = new CartService();
        private IProductService productService = new ProductServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCartItems();
            }
        }

        private void LoadCartItems()
        {
            List<ServiceApi.Cart> cartItems = _cartService.GetCartItems();
            Double subTotal = cartItems.Sum(c => c.Cantidad * c.PrecioUnitario);
            Double taxes = subTotal * 0.13;
            Double total = subTotal + taxes;

            lblSubTotal.Text = $"{subTotal:C2}";
            lblTaxes.Text = $"{taxes:C2}";
            lblTotal.Text = $"{total:C2}";

            gvCart.DataSource = cartItems.Select(c =>
            {
                Product product = GetProduct(c.ID_Producto);
                return new
                {
                    c.ID_Carrito,
                    Imagen = $"/Assets/Images/{product.ID_Producto}.png",
                    product.Nombre,
                    product.Descripcion,
                    product.Categoria,
                    c.Cantidad,
                    c.PrecioUnitario,
                    TotalPrice = c.Cantidad * c.PrecioUnitario
                };
            }).ToList();
            gvCart.DataBind();
        }

        private Product GetProduct(int productId)
        {
            return productService.GetProductById(productId);
        }

        protected void DeleteCartItem(object sender, GridViewDeleteEventArgs e)
        {
            int cartId = (int)gvCart.DataKeys[e.RowIndex].Value;
            _cartService.DeleteCartItem(cartId);
            LoadCartItems();
            ShowErrorMessage("Producto eliminado del carrito de compras");
        }

        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }



        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            _cartService.ClearCart();
            LoadCartItems();
            ShowErrorMessage("Se ha vaciado el carrito de compras");
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int cartId = Convert.ToInt32(e.CommandArgument);

            // Confirm deletion if confirmation dialog was displayed
            if (Page.ClientScript.IsClientScriptBlockRegistered("confirmDelete"))
            {
                bool confirmed = ScriptManager.GetCurrent(this).IsInAsyncPostBack;
                if (!confirmed)
                    return;  // User canceled deletion through confirmation dialog
            }

            _cartService.DeleteCartItem(cartId);

            LoadCartItems();
            ShowErrorMessage("Producto eliminado del carrito de compras");

        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            int cartId = Convert.ToInt32(e.CommandArgument);
            int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow row = gvCart.Rows[rowIndex];
            int quantity = int.Parse((row.FindControl("txtQuantity") as TextBox).Text);

            ServiceApi.Cart cartItem = _cartService.GetCartItems().FirstOrDefault(c => c.ID_Carrito == cartId);
            if (cartItem != null)
            {
                _cartService.UpdateCartItemQuantity(cartId, quantity);
            }
            gvCart.EditIndex = -1;

            LoadCartItems();
            ShowErrorMessage("Producto actualizado en el carrito de compras");
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {

        }

        protected void lnkContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}