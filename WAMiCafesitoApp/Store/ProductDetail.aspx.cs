using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.Helpers;
using WAMiCafesitoApp.ServiceApi;
using WAMiCafesitoApp.Services;

namespace WAMiCafesitoApp.Store
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        private CartService _cartService = new CartService();   
        private IProductService productService = new ProductServiceClient();
        private Auth auth = new Auth();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {

                    int productId;

                    if (int.TryParse(Request.QueryString["id"], out productId))
                    {

                        Product product = productService.GetProductById(productId);
                        Session["SelectedProduct"] = product;

                        if (product != null)
                        {
                            RenderProductDetail(product);
                            Session["Product"] = product;
                        }
                        else
                        {
                            Response.Write("Product not found.");
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void RenderProductDetail(Product product)
        {
            if (product != null)
            {

                lblProductName.Text = product.Nombre;
                lblProductDescription.Text = product.Descripcion;
                lblCategory.Text = product.Categoria;
                string imageUrl = $"/Assets/Images/{product.ID_Producto}.png";
                imgProduct.ImageUrl = imageUrl;
                imgProduct.Attributes.Add("onerror", "this.onerror=null; this.src='/Assets/Images/default.png';");
                setPrice(product.Precio);
            }
            else
            {
                Response.Write("Product not found.");
            }
        }

        protected void setPrice(double precio)
        {
            int priceInteger = (int)precio;
            int priceDecimal = (int)((precio - priceInteger) * 100);

            lblPriceInteger.Text = priceInteger.ToString();
            lblPriceDecimal.Text = priceDecimal.ToString("00");
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            
            Product product = Session["SelectedProduct"] as Product;
            int quantity = Convert.ToInt32(txtQuantity.Text);
            
            if (product != null && quantity != 0)
            {

                List<ServiceApi.Cart> cartItems = _cartService.AddOrUpdateCartItem(product, quantity);

                // Update the session with the updated cart items
                Session["CartItems"] = cartItems;
                
                string plural = quantity > 1 ? "s" : "";
                
                ShowErrorMessage(
                    $"{quantity} Producto{plural}" +
                    $" agregado{plural} al carrito."
                    );
            }


        }

        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }
    }
}