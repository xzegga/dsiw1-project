using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        ServiceApi.ICategoryService categoryService = new ServiceApi.CategoryServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }

        protected void LoadCategories()
        {
            List<ServiceApi.Category> categories = categoryService.GetAllCategories().ToList();

            if (categories.Count > 0)
            {
                categoryRepeater.DataSource = categories;
                categoryRepeater.DataBind();

            }
        }

    }
}