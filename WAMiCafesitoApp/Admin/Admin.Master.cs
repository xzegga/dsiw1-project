using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WAMiCafesitoApp.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        ServiceApi.ICategoryService categoryService = new ServiceApi.CategoryServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null)
                {
                    HideLoginLink();
                }

                if (Session["CartItems"] != null)
                {
                    HideLoginLink();
                }

            }

        }

        protected void RedirectLogin()
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void HideLoginLink()
        {
            UnauthenticatedLnks.Visible = false;
            AuthenticatedLnks.Visible = true;

        }

        protected void closeSessionLnk_Click(object sender, EventArgs e)
        {
            // Almacenar el objeto de usuario en la sesión
            Session["UserId"] = null;
            Session["RoleId"] = null;
            Response.Redirect("/Default.aspx");
        }

    }
}