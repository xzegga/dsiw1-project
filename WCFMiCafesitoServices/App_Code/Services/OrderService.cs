using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace MiCafesito
{
    public class OrderService : IOrderService
    {
        private CustomConfigurationManager _config;
        private SqlConnection connection;

        public OrderService()
        {
            _config = new CustomConfigurationManager();
            connection = new SqlConnection(_config.ConnectionString);
        }

        public void AddOrder(Order order)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_InsertarPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Usuario", order.ID_Usuario);
                    command.Parameters.AddWithValue("@Factura", order.Factura);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo agregar el pedido"); }
            finally { connection.Close(); }
        }

        public void DeleteOrder(int id)
        {
            try
            {

                
                using (SqlCommand command = new SqlCommand("SP_EliminarPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Pedido", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo eliminar el pedido"); }
            finally { connection.Close(); }
        }

        public List<Order> GetAllOrders()
        {

            List<Order> orders = new List<Order>();

            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarPedidos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.ID_Pedido = Convert.ToInt32(reader["ID_Pedido"]);
                            order.ID_Usuario = Convert.ToInt32(reader["ID_Usuario"]);
                            order.FechaPedido = Convert.ToDateTime(reader["Fecha"]);
                            order.Estado = reader["Estado"].ToString();
                            order.Factura = reader["Factura"].ToString();

                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener la lista de pedidos"); }
            finally { connection.Close(); }

            return orders;
        }

        public List<Order> GetAllOrdersByUserId(int id)
        {

            List<Order> orders = new List<Order>();

            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarPedidosByUserID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Usuario", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order();
                            order.ID_Pedido = Convert.ToInt32(reader["ID_Pedido"]);
                            order.ID_Usuario = Convert.ToInt32(reader["ID_Usuario"]);
                            order.FechaPedido = Convert.ToDateTime(reader["Fecha"]);
                            order.Estado = reader["Estado"].ToString();
                            order.Factura = reader["Factura"].ToString();

                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener la lista de pedidos"); }
            finally { connection.Close(); }

            return orders;
        }

        public Order GetOrderById(int id)
        {

            Order order = new Order();

            try
            {
                using (SqlCommand command = new SqlCommand("SP_ObtenerPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Pedido", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            order.ID_Pedido = Convert.ToInt32(reader["ID_Pedido"]);
                            order.ID_Usuario = Convert.ToInt32(reader["ID_Usuario"]);
                            order.FechaPedido = Convert.ToDateTime(reader["Fecha"]);
                            order.Estado = reader["Estado"].ToString();
                            order.Factura = reader["Factura"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener el pedido"); }
            finally { connection.Close(); }

            return order;
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Pedido", order.ID_Pedido);
                    command.Parameters.AddWithValue("@ID_Usuario", order.ID_Usuario);
                    command.Parameters.AddWithValue("@Factura", order.Factura);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo actualizar el pedido"); }
            finally { connection.Close(); }
        }
    }
}