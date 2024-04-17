using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MiCafesito
{
    public class ProductsService : IProductService
    {
        private CustomConfigurationManager _config;
        private SqlConnection connection;

        public ProductsService()
        {
            _config = new CustomConfigurationManager();
            connection = new SqlConnection(_config.ConnectionString);
        }
        public void AddProduct(Product productos)
        {

            try
            {
                using (SqlCommand command = new SqlCommand("SP_InsertarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", productos.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                    command.Parameters.AddWithValue("@Precio", productos.Precio);
                    command.Parameters.AddWithValue("@ID_Categoria", productos.ID_Categoria);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo agregar el producto"); }
            finally { connection.Close(); }

        }

        public void DeleteProducto(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_EliminarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Producto", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo eliminar el producto"); }
            finally { connection.Close(); }
        }

        public List<Product> GetAllProduct()
        {

            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Product> productos = new List<Product>();

                        while (reader.Read())
                        {
                            Product producto = new Product();

                            producto.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            producto.Nombre = reader["Nombre"].ToString();
                            producto.Descripcion = reader["Descripcion"].ToString();
                            producto.Precio = Convert.ToDouble(reader["Precio"].ToString());
                            producto.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);

                            productos.Add(producto);
                        }

                        return productos;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener la lista de productos"); }
            finally { connection.Close(); }
        }

        public Product GetProductById(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ObtenerProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Producto", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Product productos = new Product();

                        while (reader.Read())
                        {
                            productos.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            productos.Nombre = reader["Nombre"].ToString();
                            productos.Descripcion = reader["Descripcion"].ToString();
                            productos.Precio = Convert.ToDouble(reader["Precio"].ToString());
                            productos.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                        }

                        return productos;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener el producto"); }
            finally { connection.Close(); }

            return null;
        }

        public void UpdateProduct(Product productos)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Producto", productos.ID_Producto);
                    command.Parameters.AddWithValue("@Nombre", productos.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", productos.Descripcion);
                    command.Parameters.AddWithValue("@Precio", productos.Precio);
                    command.Parameters.AddWithValue("@ID_Categoria", productos.Precio);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo actualizar el producto"); }
            finally { connection.Close(); }
        }
    }
}
