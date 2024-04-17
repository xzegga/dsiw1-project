using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MiCafesito
{
    public class CategoryService : ICategoryService
    {
        private CustomConfigurationManager _config;
        private SqlConnection connection;

        public CategoryService()
        {
            _config = new CustomConfigurationManager();
            connection = new SqlConnection(_config.ConnectionString);
        }

        public void AddCategory(Producto producto)
        {

            try
            {
                using (SqlCommand command = new SqlCommand("SP_InsertarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);
                    command.Parameters.AddWithValue("@ID_Categoria", producto.ID_Categoria);

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

        public List<Productos> GetAllCategories()
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Productos> producto = new List<Productos>();

                        while (reader.Read())
                        {
                            Productos category = new Productos();
                            category.ID_Productos = Convert.ToInt32(reader["ID_Productos"]);
                            category.Nombre = reader["Nombre"].ToString();
                            category.Descripcion = reader["Descripcion"].ToString();
                            category.Precio = reader["Precio"].ToString();

                            producto.Add(Productos);
                        }

                        return producto;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudieron obtener la lista de productos"); }
            finally { connection.Close(); }
        }

        public Productos GetCategoryById(int id)
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
                        Productos producto = new Productos();

                        while (reader.Read())
                        {
                            producto.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            producto.Nombre = reader["Nombre"].ToString();
                            producto.Descripcion = reader["Descripcion"].ToString();
                            producto.Precio = reader["Precio"].ToString();
                        }

                        return Productos;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener el producto"); }
            finally { connection.Close(); }

            return null;
        }

        public void UpdateCategory(Productos Producto)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Producto", Producto.ID_Producto);
                    command.Parameters.AddWithValue("@Nombre", Producto.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", Producto.Descripcion);
                    command.Parameters.AddWithValue("@Precio", Producto.Precio);
                    command.Parameters.AddWithValue("@ID_Categoria", Producto.Precio);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo actualizar el producto"); }
            finally { connection.Close(); }
        }
    }
}
