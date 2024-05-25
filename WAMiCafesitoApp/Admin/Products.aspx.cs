using System;
using System.Collections.Generic;
using System.IO;
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
;
                if (!string.IsNullOrEmpty(Request.QueryString["action"]))
                {
                    String action = Request.QueryString["action"];
                    switch (action)
                    {
                        case "insert":
                            ShowErrorMessage("Producto agregado correctamente");
                            break;
                        case "update":
                            ShowErrorMessage("Producto actualizado correctamente");
                            break;
                        case "delete":
                            ShowErrorMessage("Producto eliminado correctamente");
                            break;
                    }
                }
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
                    c.Destacado,
                    Imagen = $"/Assets/Images/{c.ID_Producto}.png",                    
                };
            }).ToList();

            ProductsGridView.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfDeleteProductId.Value);
            productService.DeleteProduct(id);
            BindOrdersGrid();
            ShowErrorMessage("Producto eliminado correctamente");

        }


        protected void lnkViewOrder_Command(object sender, CommandEventArgs e)
        {
            int productId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("~/Admin/Product.aspx?id=" + productId);
        }

        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }

        protected void lnkAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Product.aspx");
        }
    }
}