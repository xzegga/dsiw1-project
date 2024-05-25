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
    public partial class OrderDetails : System.Web.UI.Page
    {
        IOrderService orderService = new OrderServiceClient();
        IOrderDetailsService orderDetailsService = new OrderDetailsServiceClient();
        private IUserService userService = new UserServiceClient();
        private IProductService productService = new ProductServiceClient();
        private Auth auth = new Auth();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {

                    int orderId;
                    if (int.TryParse(Request.QueryString["id"], out orderId))
                    {


                        Order order = orderService.GetOrderById(orderId);
                        Session["SelectedOrder"] = order;


                        if (order != null)
                        {
                            RenderOrder(order);
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


        private Product GetProduct(int productId)
        {
            return productService.GetProductById(productId);
        }
        protected void RenderOrder(Order order)
        {
            if (order != null)
            {
                lblOrderID.Text = order.ID_Pedido.ToString();
                lblOrderDate.Text = order.FechaPedido.ToString();
                lblInvoice.Text = order.Factura;
                lblSubTotal.Text = $"{order.SubTotal:C2}";
                lblTaxes.Text = $"{(order.SubTotal * 0.13):C2}";
                lblTotal.Text = $"{(order.SubTotal + (order.SubTotal * 0.13)):C2}";

                List<OrderDetail> orderDetails = orderDetailsService.GetAllOrderDetailByOrderId(order.ID_Pedido).ToList();

                gvOrderDetails.DataSource = orderDetails.Select(c =>
                {
                    Product product = GetProduct(c.ID_Producto);
                    return new
                    {
                        product.Nombre,
                        Imagen = $"/Assets/Images/{product.ID_Producto}.png",
                        c.Cantidad,
                        c.PrecioUnitario,
                        Impuestos = $"{(c.Cantidad * c.PrecioUnitario * 0.13):C2}",
                        Total = $"{(c.Cantidad * c.PrecioUnitario):C2}",
                    };
                }).ToList();


                gvOrderDetails.DataBind();
            }
            else
            {
                Response.Write("Orden no encontrada.");
            }
        }


        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
            hdnToastType.Value = "info";
        }
    }
}