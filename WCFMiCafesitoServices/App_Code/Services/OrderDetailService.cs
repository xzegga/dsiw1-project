using System;
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

        public void AddOrderDetail(OrderDetails orderDetails)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_InsertarDetallePedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", detallePedidos.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", detallePedidos.Descripcion);
                    command.Parameters.AddWithValue("@Precio", detallePedidos.Precio);
                    command.Parameters.AddWithValue("@ID_Categoria", detallePedidos.ID_Categoria);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo agregar el detalle de pedido"); }
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

        public List<OrderDetails> GetAllOrderDetail()
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarDetallePedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<OrderDetails> detallePedidos = new List<OrderDetails>();

                        while (reader.Read())
                        {
                            OrderDetails orderDetail = new OrderDetails();
                            orderDetail.ID_Pedido = Convert.ToInt32(reader["ID_Pedido"]);

                            detallePedidos.Add(orderDetail);
                        }

                        return detallePedidos;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudieron obtener el detalle del pedido"); }
            finally { connection.Close(); }
        }

    



    public void UpdateOrderDetail(OrderDetails orderDetails)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarDetallePedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Detalle", detallePedidos.ID_Detalle);
                    command.Parameters.AddWithValue("@ID_Pedido", detallePedidos.ID_Pedido);
                    command.Parameters.AddWithValue("@ID_Producto", detallePedidos.ID_Producto);
                    command.Parameters.AddWithValue("@Cantidad", detallePedidos.Cantidad);
                    command.Parameters.AddWithValue("@PrecioUnitario", detallePedidos.PrecioUnitario);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo actualizar el detalle de pedido"); }
            finally { connection.Close(); }
        }
    }
}
