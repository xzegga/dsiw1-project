using System;
using WAMiCafesitoApp.Helpers;

namespace WAMiCafesitoApp.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        private Auth auth = new Auth();

        ServiceApi.ICategoryService categoryService = new ServiceApi.CategoryServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            auth.IsNotAdminThenRedirect();
            if (!IsPostBack)
            {

            }

        }

        protected void RedirectLogin()
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void closeSessionLnk_Click(object sender, EventArgs e)
        {
            // Almacenar el objeto de usuario en la sesión
            Session["UserId"] = null;
            Session["RoleId"] = null;
            Response.Redirect("/Default.aspx");
        }

        protected void lnkProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Products.aspx");
        }
    }
}