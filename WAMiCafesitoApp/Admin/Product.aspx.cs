using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.ServiceApi;
using WAMiCafesitoApp.Services;

namespace WAMiCafesitoApp.Admin
{
    public partial class Producto : System.Web.UI.Page
    {
        ICategoryService categoryService = new CategoryServiceClient();
        IProductService productService = new ProductServiceClient();
        private const string ImageFolder = "~/Assets/Images/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {

                    int id;
                    if (int.TryParse(Request.QueryString["id"], out id))
                    {

                        RenderProductDetail(id);
                    }
                }
            }
        }

        private void RenderProductDetail(int id)
        {
            Product product = productService.GetProductById(id);
            txtNombre.Text = product.Nombre;
            hdnProductId.Value = product.ID_Producto.ToString();
            txtDescripcion.Text = product.Descripcion;
            txtPrecio.Text = product.Precio.ToString();
            ddlCategoria.SelectedValue = product.ID_Categoria.ToString();
            chkDestacado.Checked = product.Destacado;
            // Agrego clase de bootstrap directo en code behind para que no haga un wrapper al control
            chkDestacado.InputAttributes.Add("class", "form-check-input");

            string imagePath = Server.MapPath(ImageFolder + id + ".png");

            if (File.Exists(imagePath))
            {
                imgProduct.ImageUrl = ImageFolder + id + ".png";
                imgProductThumb.ImageUrl = ImageFolder + id + ".png";
            }
            else
            {
                imgProduct.ImageUrl = ImageFolder + "Default.png";
                imgProductThumb.ImageUrl = ImageFolder + "Default.png";
            }
        }

        private void BindCategories()
        {
            List<Category> categories = categoryService.GetAllCategories().ToList();
            ddlCategoria.DataSource = categories;
            ddlCategoria.DataTextField = "Nombre";
            ddlCategoria.DataValueField = "ID_Categoria";
            ddlCategoria.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            Product product = new Product
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Precio = Convert.ToDouble(txtPrecio.Text),
                ID_Categoria = Convert.ToInt32(ddlCategoria.SelectedValue),
                Destacado = chkDestacado.Checked
            };


            int id;
            if (int.TryParse(hdnProductId.Value, out id))
            {
                product.ID_Producto = id;

                Boolean valid = ValidateProductAttributes(product);
                if (!valid) return;

                productService.UpdateProduct(product);
                SaveProductImage(id);
                Response.Redirect("/Admin/Products.aspx?action=update");
            }
            else
            {
                Boolean valid = ValidateProductAttributes(product);
                if (!valid) return;

                int productId = productService.AddProduct(product);
                if (productId > 0)
                {
                    SaveProductImage(productId);
                }

                Response.Redirect("/Admin/Products.aspx?action=insert");
            }
        }


        private void SaveProductImage(int productId)
        {
            if (fuImagen.HasFile)
            {
                string fileName = productId + ".png"; // Cambiar la extensión a PNG
                string filePath = Server.MapPath(ImageFolder + fileName);

                // Guardar el archivo de imagen temporalmente
                string tempFilePath = Server.MapPath(ImageFolder + "temp") + fuImagen.FileName;
                fuImagen.SaveAs(tempFilePath);

                // Convertir el archivo de imagen a formato PNG
                using (var image = System.Drawing.Image.FromFile(tempFilePath))
                {
                    image.Save(filePath, ImageFormat.Png);
                }

                // Eliminar el archivo de imagen temporal
                File.Delete(tempFilePath);

                imgProduct.ImageUrl = ImageFolder + fileName;
            }
        }

        protected Boolean ValidateProductAttributes(Product product)
        {

            if (!Validator.ValidateString(product.Nombre))
            {
                ShowErrorMessage("Nombre de producto no válido.");
                return false;
            }

            if (!Validator.ValidateString(product.Descripcion))
            {
                ShowErrorMessage("Descripción de producto no válida.");
                return false;
            }

            if (!Validator.ValidateDecimalNumber(product.Precio.ToString()))
            {
                ShowErrorMessage("Precio de producto no válido.");
                return false;
            }

            return true;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfDeleteProductId.Value);

            ShowErrorMessage("Producto eliminado correctamente");

        }


        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }
    }
}