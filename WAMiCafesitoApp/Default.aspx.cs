using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAMiCafesitoApp
{
    public partial class Default : System.Web.UI.Page
    {
        ServiceApi.IProductService productService = new ServiceApi.ProductServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            LoadFeaturedProducts();
        }

      
        protected void LoadFeaturedProducts()
        {
            List<ServiceApi.Product> products = productService.GetProductsFeatured().ToList();
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
    }
}