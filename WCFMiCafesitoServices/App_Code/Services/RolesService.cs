using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace MiCafesito
{
    public class RolesService: IRolesService
    {
        private CustomConfigurationManager _config;
        private SqlConnection connection;

        public RolesService()
        {
            _config = new CustomConfigurationManager();
            connection = new SqlConnection(_config.ConnectionString);
        }

        public List<Role> GetAllRoles()
        {
            
            List<Role> roles = new List<Role>();

            try
            {
                using (SqlCommand command = new SqlCommand("SP_ListarRoles", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Role role = new Role();
                            role.ID_Rol = Convert.ToInt32(reader["ID_Rol"]);
                            role.Nombre = reader["Nombre"].ToString();

                            roles.Add(role);
                        }
                    }
                }
            }
            catch (Exception ex) { throw new ArgumentException("No se pudo obtener la lista de roles"); }
            finally { connection.Close(); }

            return roles;
        }

    }
}