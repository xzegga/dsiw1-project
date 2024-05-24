using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp.Admin
{
    public partial class Products : System.Web.UI.Page
    {
        IProductService productService = new ProductServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrdersGrid();
            }
        }

        private void BindOrdersGrid()
        {
            List<Product> products = productService.GetAllProducts().ToList();
            ProductsGridView.DataSource = products.Select(c =>
            {
                return new
                {
                    c.ID_Producto,
                    c.Nombre,
                    c.Descripcion,
                    c.Categoria,
                    c.Precio,
                    Imagen = $"/Assets/Images/{c.ID_Producto}.png",                    
                };
            }).ToList();

            ProductsGridView.DataBind();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfDeleteCategoryId.Value);
            productService.DeleteProduct(id);
            BindOrdersGrid();
            ShowErrorMessage("Producto eliminado correctamente");

        }

        protected void lnkViewOrder_Command(object sender, CommandEventArgs e)
        {
            int productId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("~/Admin/ProductDetail.aspx?productId=" + productId);
        }

        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }
    }
}