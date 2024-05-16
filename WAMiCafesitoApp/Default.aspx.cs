using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp
{
    public partial class Default : System.Web.UI.Page
    {
        IProductService productService = new ProductServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            LoadFeaturedProducts();
        }

      
        protected void LoadFeaturedProducts()
        {
            List<Product> products = productService.GetProductsFeatured().ToList();
            if (products.Count > 0)
            {
                featuredProductsRepeater.DataSource = products;
                featuredProductsRepeater.DataBind();

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
             
                    ServiceApi.Product product = (ServiceApi.Product)e.Item.DataItem;

                    if (product != null)
                    {
             
                        verDetalleLink.NavigateUrl = $"Store/ProductDetail.aspx?id={product.ID_Producto}";
                    }
                }
            }
        }
    }
}