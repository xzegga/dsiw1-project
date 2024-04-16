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

        public void AddCategory(Category category)
        {

            try
            {
                using (SqlCommand command = new SqlCommand("SP_InsertarCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nombre", category.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", category.Descripcion);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo agregar la categoria"); }
            finally { connection.Close(); }

        }

        public void DeleteCategory(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_EliminarCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Categoria", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo eliminar la categoria"); }
            finally { connection.Close(); }
        }

        public List<Category> GetAllCategories()
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarCategorias", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Category> categories = new List<Category>();

                        while (reader.Read())
                        {
                            Category category = new Category();
                            category.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                            category.Nombre = reader["Nombre"].ToString();
                            category.Descripcion = reader["Descripcion"].ToString();

                            categories.Add(category);
                        }

                        return categories;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudieron obtener las categorias"); }
            finally { connection.Close(); }
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ObtenerCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Categoria", id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Category category = new Category();

                        while (reader.Read())
                        {
                            category.ID_Categoria = Convert.ToInt32(reader["ID_Categoria"]);
                            category.Nombre = reader["Nombre"].ToString();
                            category.Descripcion = reader["Descripcion"].ToString();
                        }

                        return category;
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener la categoria"); }
            finally { connection.Close(); }

            return null;
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("SP_ActualizarCategoria", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID_Categoria", category.ID_Categoria);
                    command.Parameters.AddWithValue("@Nombre", category.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", category.Descripcion);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo actualizar la categoria"); }
            finally { connection.Close(); }
        }
    }
}