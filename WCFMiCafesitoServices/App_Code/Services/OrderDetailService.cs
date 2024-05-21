using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MiCafesito
{
    public class ProductDetailService : IOrderDetailsService
    {
        private CustomConfigurationManager _config;
        private SqlConnection connection;

        public ProductDetailService()
        {
            _config = new CustomConfigurationManager();
            connection = new SqlConnection(_config.ConnectionString);
        }

        public void AddOrderDetail(OrderDetail orderDetails)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_InsertarDetallePedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Pedido", orderDetails.ID_Pedido);
                    command.Parameters.AddWithValue("@ID_Producto", orderDetails.ID_Producto);
                    command.Parameters.AddWithValue("@Cantidad", orderDetails.Cantidad);
                    command.Parameters.AddWithValue("@PrecioUnitario", orderDetails.PrecioUnitario);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo agregar el detalle del pedido"); }
            finally { connection.Close(); }
        }

        public void DeleteOrderDetail(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_EliminarDetallePedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Detalle", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo eliminar el detalle del pedido"); }
            finally { connection.Close(); }
        }

        public void DeleteOrderDetailByOrderId(int id)
        {
            // SP_EliminarDetallesPedido
            // ID_Pedido INT

            try
            {
                using (SqlCommand command = new SqlCommand("SP_EliminarDetallesPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Pedido", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo eliminar los detalles del pedido"); }
            finally { connection.Close(); }
        }

        public List<OrderDetail> GetAllOrderDetailByOrderId(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarDetallesPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Pedido", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<OrderDetail> detallePedidos = new List<OrderDetail>();

                        while (reader.Read())
                        {
                            OrderDetail orderDetail = new OrderDetail();
                            orderDetail.ID_Detalle = Convert.ToInt32(reader["ID_Detalle"]);
                            orderDetail.ID_Pedido = Convert.ToInt32(reader["ID_Pedido"]);
                            orderDetail.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            orderDetail.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            orderDetail.PrecioUnitario = Convert.ToDouble(reader["PrecioUnitario"]);
                            detallePedidos.Add(orderDetail);
                        }

                        return detallePedidos;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudieron obtener el detalle del pedido"); }
            finally { connection.Close(); }
        }

        public void UpdateOrderDetail(OrderDetail orderDetails)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarDetallePedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Detalle", orderDetails.ID_Detalle);
                    command.Parameters.AddWithValue("@ID_Pedido", orderDetails.ID_Pedido);
                    command.Parameters.AddWithValue("@ID_Producto", orderDetails.ID_Producto);
                    command.Parameters.AddWithValue("@Cantidad", orderDetails.Cantidad);
                    command.Parameters.AddWithValue("@PrecioUnitario", orderDetails.PrecioUnitario);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo actualizar el detalle del pedido"); }
            finally { connection.Close(); }
        }
    }
}
