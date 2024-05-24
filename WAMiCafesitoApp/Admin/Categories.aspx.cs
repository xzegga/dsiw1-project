using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.ServiceApi;
using WAMiCafesitoApp.Services;

namespace WAMiCafesitoApp.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        private ICategoryService _categoryService = new CategoryServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategorias();
            }
        }

        private void BindCategorias()
        {
            var categories = _categoryService.GetAllCategories();
            gvCategorias.DataSource = categories;
            gvCategorias.DataBind();
        }

        protected void gvCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCategorias.EditIndex = e.NewEditIndex;
            BindCategorias();
        }

        protected void gvCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvCategorias.Rows[e.RowIndex];
            int id = Convert.ToInt32(gvCategorias.DataKeys[e.RowIndex].Values[0]);
            string nombre = ((TextBox)row.Cells[1].Controls[0]).Text;
            string descripcion = ((TextBox)row.Cells[2].Controls[0]).Text;

            Category category = new Category
            {
                ID_Categoria = id,
                Nombre = nombre,
                Descripcion = descripcion
            };

            _categoryService.UpdateCategory(category);
            gvCategorias.EditIndex = -1;
            BindCategorias();
            ShowErrorMessage("Categoría actualizada con éxito");
        }

        protected void gvCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategorias.EditIndex = -1;
            BindCategorias();
        }

        protected void gvCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvCategorias.DataKeys[e.RowIndex].Values[0]);
            _categoryService.DeleteCategory(id);
            BindCategorias();
            ShowErrorMessage("Categoría eliminado del carrito de compras");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(hfDeleteCategoryId.Value);
            _categoryService.DeleteCategory(id);
            BindCategorias();
            ShowErrorMessage("Producto eliminado correctamente");

        }

        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {

            if (validateAttribute(txtNombre.Text, txtDescripcion.Text) == false) return;

            Category category = new Category
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text
            };

            _categoryService.AddCategory(category);
                       
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;

            BindCategorias();
            ShowErrorMessage("Categoría agregada correctamente");
        }

        protected Boolean validateAttribute(string nombre, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
            {
                ShowErrorMessage("Nombre y descripción no pueden estar vacios");
                return false;
            }
                

            if (!Validator.ValidateString(nombre))
            {
                ShowErrorMessage("Nombre de categoría no válido.");
                return false;
            }
                

            if (!Validator.ValidateString(descripcion))
            {
                ShowErrorMessage("Descripción de categoría no válido.");
                return false;
            }

            return true;

        }
    }
}