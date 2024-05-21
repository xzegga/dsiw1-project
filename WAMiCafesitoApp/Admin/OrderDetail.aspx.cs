using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp.Admin
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        IOrderService orderService = new OrderServiceClient();
        IOrderDetailsService orderDetailsService = new OrderDetailsServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {

                    int orderId;

                    if (int.TryParse(Request.QueryString["id"], out orderId))
                    {

                        
                        //Order order = orderService.GetOrderById(orderId);
                        //Session["SelectedOrder"] = order;

                        //if (order != null)
                        //{
                        //    // pendiente
                        //}
                        //else
                        //{
                        //    Response.Write("Product not found.");
                        //}
                    }
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void RenderOrder(Order order)
        {
            if (order != null)
            {

               
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


    }
}