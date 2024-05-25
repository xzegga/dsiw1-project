using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.Helpers;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp.Store
{
    public partial class OrderList : System.Web.UI.Page
    {
        private IOrderService orderService = new OrderServiceClient();

        private Auth auth = new Auth();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrdersGrid();
            }
        }

        private void BindOrdersGrid()
        {
            int userId = auth.IsAuthenticatedOrRedirect();
            
            List<Order> orders = orderService.GetAllOrdersByUserId(userId).ToList();
            OrdersGridView.DataSource = orders;


            OrdersGridView.DataSource = orders.Select(c =>
            {                
                return new
                {
                    c.ID_Pedido,
                    c.FechaPedido,
                    c.Estado,
                    c.Factura,
                    c.SubTotal
                };
            }).ToList();


            OrdersGridView.DataBind();
        }

        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int orderId = Convert.ToInt32(e.CommandArgument);

            int rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            GridViewRow row = OrdersGridView.Rows[rowIndex];
            Label lblOrderStatus = (Label)row.FindControl("lblOrderStatus");

            if (lblOrderStatus.Text != "Recibida")
            {
                ShowErrorMessage("La Orden ya está en proceso, por favor comuniquese con el adminstrador");
                return;
            }            

            orderService.DeleteOrder(orderId);
            BindOrdersGrid();
            ShowErrorMessage("Orden eliminada de forma satisfactoria");
        }

        protected void lnkViewOrder_Command(object sender, CommandEventArgs e)
        {
            int orderId = Convert.ToInt32(e.CommandArgument);
            Response.Redirect($"OrderDetail.aspx?id={orderId}");
        }
    }
}