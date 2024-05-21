using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.Helpers;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp.Admin
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        IOrderService orderService = new OrderServiceClient();
        IOrderDetailsService orderDetailsService = new OrderDetailsServiceClient();
        private IUserService userService = new UserServiceClient();
        private Auth auth = new Auth();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                auth.isAdminAuthorized();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {

                    int orderId;
                    if (int.TryParse(Request.QueryString["id"], out orderId))
                    {


                        Order order = orderService.GetOrderById(orderId);
                        Session["SelectedOrder"] = order;
                        User user = GetUser(order.ID_Usuario);

                        if (order != null)
                        {
                            RenderOrder(order, user);

                        }
                        else
                        {
                            Response.Write("Product not found.");
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }



        private User GetUser(int userId)
        {

            return userService.GetUserById(userId);
        }
        protected void RenderOrder(Order order, User user)
        {
            if (order != null)
            {
                lblOrderID.Text = order.ID_Pedido.ToString();
                lblUser.Text = $"{user.Nombre} {user.Apellido}";
                lblOrderDate.Text = order.FechaPedido.ToString();
                ddlStatus.SelectedIndex = ddlStatus.Items.IndexOf(ddlStatus.Items.FindByText(order.Estado));
                lblInvoice.Text = order.Factura;
                lblSubTotal.Text = $"{order.SubTotal:C2}";

            }
            else
            {
                Response.Write("Orden no encontrada.");
            }
        }

        private List<string> GetAvailableStates()
        {
            // Replace with your logic to retrieve available order states
            // This is a placeholder for demonstration
            return new List<string>() { "Recibido", "En Proceso", "Enviado", "Entregado" };
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(Request.QueryString["id"]);
            Order order = Session["SelectedOrder"] as Order;
            order.Estado = ddlStatus.SelectedItem.Text;

            orderService.UpdateOrder(order);

            ShowErrorMessage("Estado de la orden actualizada con éxito");
        }


        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }
    }
}