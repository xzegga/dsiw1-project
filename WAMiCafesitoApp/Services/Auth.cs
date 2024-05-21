using System;
using System.Web;

namespace WAMiCafesitoApp.Helpers
{
    public class Auth
    {
        public Auth() { }
        public int isAuthenticated()
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
        public int isAuthenticatedOrRedirect()
        {
            int userId = isAuthenticated();

            if (userId.Equals(0)) HttpContext.Current.Response.Redirect("/login.aspx");

            return userId;
        }

    }
}