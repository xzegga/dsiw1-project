using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Activities.Expressions;

public class UserService : IUserService
{
    private CustomConfigurationManager _config;
    private SqlConnection connection;

    public UserService()
    {
        _config = new CustomConfigurationManager();
        connection = new SqlConnection(_config.ConnectionString);
    }

    public void AddUser(User user)
    {
        int newUserId = 0;

        // Create connection and command objects
        try
        {
            using (SqlCommand command = new SqlCommand("SP_CrearUsuario", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddWithValue("@Nombre", user.Nombre);
                command.Parameters.AddWithValue("@Apellido", user.Apellido);
                command.Parameters.AddWithValue("@FechaNacimiento", user.Fecha_Nacimiento);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Telefono", user.Telefono);
                command.Parameters.AddWithValue("@Estado", user.Estado);
                command.Parameters.AddWithValue("@ID_Rol", user.ID_Rol);
                command.Parameters.AddWithValue("@Patron", _config.Patron);

                // Open connection and execute the stored procedure
                connection.Open();
                object result = command.ExecuteScalar();

                // Check if the result is not null and convert it to int
                if (result != null)
                {
                    newUserId = Convert.ToInt32(result);
                }
            }
        }
        catch (Exception ex) { throw new ArgumentException("No se pudo agregar el usuario"); }
        finally { connection.Close(); }
    }

    public void DeleteUser(int id)
    {

        try
        {
            using (SqlCommand command = new SqlCommand("SP_EliminarUsuario", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID_Usuario", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException("No se pudo eliminar el usuario");
        }
        finally { connection.Close(); }
    }

    public List<User> GetAllUsers()
    {
        List<User> userList = new List<User>();

        try
        {
            using (SqlCommand command = new SqlCommand("SP_ListarUsuarios", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Patron", _config.Patron);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            ID_Usuario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Fecha_Nacimiento = reader.GetDateTime(3),
                            Email = reader.GetString(4),
                            Telefono = reader.IsDBNull(5) ? null : reader.GetString(5),
                            ID_Rol = reader.GetInt32(6),
                            NombreRol = reader.GetString(7),
                            Estado = reader.GetString(8),
                            Fecha_Registro = reader.GetDateTime(9)
                        };

                        userList.Add(user);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al obtener la lista de usuarios");
        }
        finally { connection.Close(); }

        return userList;
    }

    public User GetUserById(int id)
    {
        User user;

        try
        {
            using (SqlCommand command = new SqlCommand("SP_LeerUsuario", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID_Usuario", id);
                command.Parameters.AddWithValue("@Patron", _config.Patron);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            ID_Usuario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Fecha_Nacimiento = reader.GetDateTime(3),
                            Email = reader.GetString(4),
                            Telefono = reader.GetString(5),
                            ID_Rol = reader.GetInt32(6),
                            NombreRol = reader.GetString(7),
                            Estado = reader.GetString(8),
                            Fecha_Registro = reader.GetDateTime(9)
                        };

                        return user;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Error al obtener el usuario");
        }
        finally { connection.Close(); }

        return null;

    }

    public int Login(string user, string password)
    {
        int newUserId = 0;
        try
        {
            using (SqlCommand command = new SqlCommand("SP_ValidarUsuario", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email", user);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Patron", _config.Patron);

                connection.Open();
                object result = command.ExecuteScalar();

                // Check if the result is not null and convert it to int
                if (result != null)
                {
                    newUserId = Convert.ToInt32(result);
                }

            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Usuario y/o contrasena invalidas");
        }
        finally { connection.Close(); }

        return newUserId;
    }

    public void ResetPassword(string email, string password, string newPassword, string confirmPassword)
    {
        try
        {
            using (SqlCommand command = new SqlCommand("SP_ResetearContrasena", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@PasswordActual", password);
                command.Parameters.AddWithValue("@NuevaContrasena", newPassword);
                command.Parameters.AddWithValue("@VerificarContrasena", confirmPassword);
                command.Parameters.AddWithValue("@Patron", _config.Patron);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException("No se pudo resetear la contrasena");
        }
        finally { connection.Close(); }
    }

    public void SearchUser(SearchCriteria criteria)
    {
        // Implementation
    }

    public void UpdateUser(User user)
    {
        try
        {
            using (SqlCommand command = new SqlCommand("SP_ActualizarUsuario", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ID_Usuario", user.ID_Usuario);
                command.Parameters.AddWithValue("@Nombre", user.Nombre);
                command.Parameters.AddWithValue("@Apellido", user.Apellido);
                command.Parameters.AddWithValue("@FechaNacimiento", user.Fecha_Nacimiento);
                command.Parameters.AddWithValue("@Telefono", user.Telefono);
                command.Parameters.AddWithValue("@Estado", user.Estado);
                command.Parameters.AddWithValue("@ID_Rol", user.ID_Rol);
                command.Parameters.AddWithValue("@Patron", _config.Patron);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException("No se pudo actualizar el usuario");
        }
        finally { connection.Close(); }


    }


}
