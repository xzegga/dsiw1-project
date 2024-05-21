using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.Helpers;
using WAMiCafesitoApp.ServiceApi;
using WAMiCafesitoApp.Services;
using static WAMiCafesitoApp.Helpers.Auth;

namespace WAMiCafesitoApp.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        // private IProductService productService = new ProductServiceClient();
        private IOrderService orderService = new OrderServiceClient();
        private IUserService userService = new UserServiceClient();
        private Auth auth = new Auth();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrdersGrid();
            }
        }

        
        private void AuthorizedUser() {
            CallBack callback = delegate (string message)
            {
                ShowErrorMessage("No tienes permisos para ver esta página");
            };
            auth.isAdminAuthorized(callback);
        }

        private void BindOrdersGrid()
        {
            AuthorizedUser();
            List<Order> orders = orderService.GetAllOrders().ToList();
            OrdersGridView.DataSource = orders;


            OrdersGridView.DataSource = orders.Select(c =>
            {
                User user = GetUser(c.ID_Usuario);
                return new
                {
                    c.ID_Pedido,
                    User = user.Nombre + ' ' + user.Apellido,                    
                    c.FechaPedido,
                    c.Estado,
                    c.Factura
                };
            }).ToList();


            OrdersGridView.DataBind();
        }

        private User GetUser(int userId)
        {
            return userService.GetUserById(userId);
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            auth.isAuthenticatedOrRedirect();
            int orderId = Convert.ToInt32(e.CommandArgument);
            orderService.DeleteOrder(orderId);
            BindOrdersGrid();
            ShowErrorMessage("Orden eliminada de forma satisfactoria");

        }


        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }

    }
}