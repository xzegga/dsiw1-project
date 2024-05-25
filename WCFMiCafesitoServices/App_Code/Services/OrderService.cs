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

        public int AddOrder(Order order)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_InsertarPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Usuario", order.ID_Usuario);
                    command.Parameters.AddWithValue("@FechaPedido", order.FechaPedido);
                    command.Parameters.AddWithValue("@SubTotal", order.SubTotal);
                    command.Parameters.AddWithValue("@Estado", order.Estado);

                    // Add output parameter for inserted ID
                    SqlParameter outputParameter = new SqlParameter("@PedidoID", SqlDbType.Int);
                    outputParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParameter);

                    connection.Open();
                    command.ExecuteNonQuery(); // Use ExecuteNonQuery for INSERT statements

                    // Retrieve inserted ID from output parameter
                    int insertedOrderID = Convert.ToInt32(outputParameter.Value);

                    return insertedOrderID;
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
                            order.FechaPedido = Convert.ToDateTime(reader["FechaPedido"]);
                            order.Estado = reader["Estado"].ToString();
                            order.Factura = reader["Factura"] == DBNull.Value ? "N/A" : reader["Factura"].ToString();
                            order.SubTotal = reader["SubTotal"] == DBNull.Value ? 0 : Convert.ToDouble(reader["SubTotal"]);

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
                            order.FechaPedido = Convert.ToDateTime(reader["FechaPedido"]);
                            order.Estado = reader["Estado"].ToString();
                            order.Factura = reader["Factura"] == DBNull.Value ? "N/A" : reader["Factura"].ToString();
                            order.SubTotal = reader["SubTotal"] == DBNull.Value ? 0 : Convert.ToDouble(reader["SubTotal"]);


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
                            order.FechaPedido = Convert.ToDateTime(reader["FechaPedido"]);
                            order.Estado = reader["Estado"].ToString();
                            order.Factura = reader["Factura"] == DBNull.Value ? "N/A" : reader["Factura"].ToString();
                            order.SubTotal = reader["SubTotal"] == DBNull.Value ? 0 : Convert.ToDouble(reader["SubTotal"]);

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
                    command.Parameters.AddWithValue("@Estado", order.Estado);
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