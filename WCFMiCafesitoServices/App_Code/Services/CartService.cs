using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MiCafesito
{
    public class CartService : ICartService
    {
        private CustomConfigurationManager _config;
        private SqlConnection connection;
        public CartService()
        {
            _config = new CustomConfigurationManager();
            connection = new SqlConnection(_config.ConnectionString);
        }

        public void AddCartItem(Cart cart)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_InsertarCarrito", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Usuario", cart.ID_Usuario);
                    command.Parameters.AddWithValue("@ID_Producto", cart.ID_Producto);
                    command.Parameters.AddWithValue("@Cantidad", cart.Cantidad);
                    command.Parameters.AddWithValue("@PrecioUnitario", cart.PrecioUnitario);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo agregar el item al carrito"); }
            finally { connection.Close(); }
        }

        public void DeleteCartItem(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_EliminarCarrito", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Carrito", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo eliminar el item del carrito"); }
            finally { connection.Close(); }
        }

        public void DeleteCartItemsByUserId(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_EliminarCarritoByUserID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Usuario", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo eliminar los items del carrito"); }
            finally
            {
                connection.Close();
            }
        }

        public List<Cart> GetCartItemsByUserId(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarCarritoByUserID", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Usuario", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Cart> cartItems = new List<Cart>();

                        while (reader.Read())
                        {
                            Cart cart = new Cart();
                            cart.ID_Carrito = Convert.ToInt32(reader["ID_Carrito"]);
                            cart.ID_Usuario = Convert.ToInt32(reader["ID_Usuario"]);
                            cart.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            cart.Cantidad = Convert.ToInt32(reader["Cantidad"]);
                            cart.PrecioUnitario = Convert.ToDouble(reader["PrecioUnitario"]);

                            cartItems.Add(cart);
                        }

                        return cartItems;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener los items del carrito"); }
            finally { connection.Close(); }


        }

        public void UpdateCartItemById(int id, int quantity, double unitprice)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarCarrito", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Carrito", id);
                    command.Parameters.AddWithValue("@Cantidad", quantity);
                    command.Parameters.AddWithValue("@PrecioUnitario", unitprice);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo actualizar el item del carrito"); }
            finally { connection.Close(); }
        }
    }
}