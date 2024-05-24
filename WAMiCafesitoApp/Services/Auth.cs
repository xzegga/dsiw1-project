using System;
using System.Web;
using static WAMiCafesitoApp.Helpers.Auth;

namespace WAMiCafesitoApp.Helpers
{
    public class Auth
    {
        public Auth() { }

        public int IsAuthenticated()
        {
            int userId = 0;

            if (
                HttpContext.Current.Session["UserId"] != null &&
                int.TryParse(HttpContext.Current.Session["UserId"].ToString(), out userId))
            {
                return userId;
            }

            return 0;
        }

        public int IsAuthenticatedOrRedirect()
        {
            int userId = IsAuthenticated();           

            if (userId.Equals(0))
            {
                string currentUrl = HttpContext.Current.Request.Url.AbsoluteUri;
                string encodedUrl = HttpUtility.UrlEncode(currentUrl);
                HttpContext.Current.Response.Redirect($"/login.aspx?returnUrl={encodedUrl}");
            }
            return userId;
        }

        public void IsNotAdminThenRedirect()
        {
            int userId = IsAuthenticated();

            // Si userId es igual a 0 o el RoleId no existe en la sesion o este es igual a 2, entonces redirigir a la pagina de Default.aspx.

            if (userId.Equals(0) || HttpContext.Current.Session["RoleId"] == null || HttpContext.Current.Session["RoleId"].ToString().Equals("2"))
            {
                HttpContext.Current.Response.Redirect("/Default.aspx");
            }
        }

        public void IsAdminThenRedirect()
        {
            int userId = IsAuthenticated();

            // Si userId es diferente de 0 y el RoleId existe en la sesion y este es igual a 1, entonces redirigir a la pagina de Admin/Default.aspx.

            if (userId != 0 && HttpContext.Current.Session["RoleId"] != null && HttpContext.Current.Session["RoleId"].ToString().Equals("1"))
            {
                HttpContext.Current.Response.Redirect("/Admin/Default.aspx");
            }

        }
    }
}