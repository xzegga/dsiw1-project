using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp.Store
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        ServiceApi.IProductService productService = new ServiceApi.ProductServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    int productId;
                    if (int.TryParse(Request.QueryString["id"], out productId))
                    {
                        LoadProductDetail(productId);
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void LoadProductDetail(int productId)
        {
            Product product = productService.GetProductById(productId);

            if (product != null)
            {
                lblProductName.Text = product.Nombre;
                lblProductDescription.Text = product.Descripcion;
                lblCategory.Text = product.Categoria;
                imgProduct.ImageUrl = $"/Assets/Images/{product.ID_Producto}.png";
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

    }
}