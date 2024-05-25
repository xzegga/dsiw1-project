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
    public partial class ResultsPage : System.Web.UI.Page
    {
        IProductService productService = new ProductServiceClient();
        ICategoryService categoryService = new CategoryServiceClient();
        private CartService _cartService = new CartService();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["criteria"]))
                {

                    string criteria = Request.QueryString["criteria"];
                    
                    if (!Validator.ValidateString(criteria))
                    {
                        ShowErrorMessage(criteria + " no es un criterio de búsqueda válido.");
                        return;
                    }

                    LoadProductsBySearchCriteria(criteria);
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }



        protected void LoadProductsBySearchCriteria(string criteria)
        {
            List<Product> products = productService.GetProductsByName(criteria).ToList();
            if (products.Count > 0)
            {
                featuredProductsRepeater.DataSource = products;
                featuredProductsRepeater.DataBind();
            } else
            {
                ShowErrorMessage("No se encontraron productos para el criterio de busqueda (" + criteria + ")");
            }
        }

        protected string GetFractionalPart(object price)
        {
            if (price != null && price != DBNull.Value)
            {
                decimal priceValue = Convert.ToDecimal(price);
                int wholePart = (int)priceValue;
                decimal fractionalPart = priceValue - wholePart;
                int cents = (int)(fractionalPart * 100);
                return cents.ToString("00");
            }
            return "00";
        }

        protected void featuredProductsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                HyperLink verDetalleLink = (HyperLink)e.Item.FindControl("btnViewDetail");

                if (verDetalleLink != null)
                {

                    Product product = (Product)e.Item.DataItem;

                    if (product != null)
                    {

                        verDetalleLink.NavigateUrl = $"/Store/ProductDetail.aspx?id={product.ID_Producto}";
                    }
                }

                LinkButton addToCartButton = (LinkButton)e.Item.FindControl("btnAddToCart");

                if (addToCartButton != null)
                {
                    Product product = (Product)e.Item.DataItem;

                    if (product != null)
                    {
                        addToCartButton.CommandArgument = product.ID_Producto.ToString();
                    }
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);

            // Retrieve the product using the productId
            ServiceApi.Product product = GetProductById(productId);

            if (product != null)
            {
                // Assuming you have a method to get the quantity, e.g., from a TextBox within the Repeater item
                RepeaterItem item = (RepeaterItem)btn.NamingContainer;
                TextBox txtQuantity = (TextBox)item.FindControl("txtQuantity");

                List<ServiceApi.Cart> cartItems = _cartService.AddOrUpdateCartItem(product, 1);

                // Update the session with the updated cart items
                Session["CartItems"] = cartItems;

                ShowErrorMessage($"Producto agregado al carrito.");

            }
        }

        private Product GetProductById(int productId)
        {
            return productService.GetProductById(productId);
        }

        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }
    }
}