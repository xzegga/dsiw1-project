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
        List<Category> categories;

        public ProductsService()
        {
            _config = new CustomConfigurationManager();
            connection = new SqlConnection(_config.ConnectionString);

            // Load Categories calling CategoryService
            CategoryService categoryService = new CategoryService();
            categories = categoryService.GetAllCategories();
        }
        public int AddProduct(Product product)
        {
            int newId = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("SP_InsertarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", product.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", product.Descripcion);
                    command.Parameters.AddWithValue("@Precio", product.Precio);                    
                    command.Parameters.AddWithValue("@ID_Categoria", product.ID_Categoria);
                    command.Parameters.AddWithValue("@Destacado", product.Destacado);

                    // Parámetro de salida para el nuevo ID
                    SqlParameter newProductId = new SqlParameter("@ID_Producto", SqlDbType.Int);
                    newProductId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(newProductId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    newId = Convert.ToInt32(newProductId.Value);
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo agregar el producto"); }
            finally { connection.Close(); }
            
            return newId;

        }

        public void DeleteProduct(int id)
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

        public List<Product> GetAllProducts()
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
                            Product product = new Product();

                            product.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            product.Nombre = reader["Nombre"].ToString();
                            product.Descripcion = reader["Descripcion"].ToString();
                            product.Precio = Convert.ToDouble(reader["Precio"].ToString());
                            product.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                            product.Categoria = reader["Categoria"].ToString();
                            product.Destacado = Convert.ToBoolean(reader["Destacado"]);
                            productos.Add(product);
                        }

                        return productos;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener la lista de productos"); }
            finally { connection.Close(); }
        }

        public List<Product> GetAllProductsByCategoryId(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarProductosByCategoryID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Categoria", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Product> products = new List<Product>();

                        while (reader.Read())
                        {
                            Product product = new Product();

                            product.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            product.Nombre = reader["Nombre"].ToString();
                            product.Descripcion = reader["Descripcion"].ToString();
                            product.Precio = Convert.ToDouble(reader["Precio"].ToString());
                            product.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                            product.ImageUrl = reader["ImageUrl"].ToString();

                            products.Add(product);
                        }

                        return products;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener la lista de productos por categoria"); }
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
                        Product product = new Product();

                        while (reader.Read())
                        {
                            product.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            product.Nombre = reader["Nombre"].ToString();
                            product.Descripcion = reader["Descripcion"].ToString();
                            product.Precio = Convert.ToDouble(reader["Precio"].ToString());
                            product.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                            product.Categoria = reader["Categoria"].ToString();
                            product.Destacado = Convert.ToBoolean(reader["Destacado"]);
                        }

                        return product;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener el producto"); }
            finally { connection.Close(); }

            return null;
        }

        public List<Product> GetProductsByName(string criteria)
        {
            // SP_ObtenerProductoByName
            // @Nombre nvarchar(100)

            try
            {
                using (SqlCommand command = new SqlCommand("SP_ObtenerProductoByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Criterio", criteria);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Product> products = new List<Product>();

                        while (reader.Read())
                        {
                            Product product = new Product();

                            product.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            product.Nombre = reader["Nombre"].ToString();
                            product.Descripcion = reader["Descripcion"].ToString();
                            product.Precio = Convert.ToDouble(reader["Precio"].ToString());
                            product.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                            product.Categoria = reader["Categoria"].ToString();
                            product.Destacado = Convert.ToBoolean(reader["Destacado"]);

                            products.Add(product);
                        }

                        return products;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener la lista de productos por nombre"); }
            finally { connection.Close(); }

        }

        public List<Product> GetProductsFeatured()
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarProductosDestacados", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Product> products = new List<Product>();

                        while (reader.Read())
                        {
                            Product product = new Product();

                            product.ID_Producto = Convert.ToInt32(reader["ID_Producto"]);
                            product.Nombre = reader["Nombre"].ToString();
                            product.Descripcion = reader["Descripcion"].ToString();
                            product.Precio = Convert.ToDouble(reader["Precio"].ToString());
                            product.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                            product.ImageUrl = reader["ImageUrl"].ToString();

                            products.Add(product);
                        }

                        return products;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener la lista de productos destacados"); }
            finally { connection.Close(); }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Producto", product.ID_Producto);
                    command.Parameters.AddWithValue("@Nombre", product.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", product.Descripcion);
                    command.Parameters.AddWithValue("@Precio", product.Precio);
                    command.Parameters.AddWithValue("@ID_Categoria", product.ID_Categoria);
                    command.Parameters.AddWithValue("Destacado", product.Destacado);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo actualizar el producto"); }
            finally { connection.Close(); }
        }
    }
}
