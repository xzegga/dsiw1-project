using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.Helpers;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp.Store
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        ServiceApi.IProductService productService = new ServiceApi.ProductServiceClient();
        Auth auth = new Auth();
        int userId;

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

        protected int isAuthenticated()
        {
            int userId;
            if (Session["UserId"] != null && int.TryParse(Session["UserId"].ToString(), out userId))
            {
                return userId;
            }

            return 0;
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
            int userId = auth.isAuthenticated();
            Product product = Session["SelectedProduct"] as Product;
            int quantity = Convert.ToInt32(txtQuantity.Text);
            List<Cart> cartItems = Session["CartItems"] as List<Cart>;

            if (product != null && quantity != 0)
            {
                if (cartItems == null)
                {
                    cartItems = new List<Cart>();
                }

                Cart cartItem = cartItems.FirstOrDefault(item => item.ID_Producto == product.ID_Producto);

                if (cartItem == null)
                {
                    Cart cart = new Cart();
                    cart.ID_Usuario = userId;
                    cart.ID_Producto = product.ID_Producto;
                    cart.Cantidad = quantity;
                    cart.PrecioUnitario = product.Precio;

                    cartItems.Add(cart);
                }
                else
                {
                    cartItem.Cantidad += quantity;
                }

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