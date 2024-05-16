﻿using System;
using WAMiCafesitoApp.ServiceApi;

namespace WAMiCafesitoApp
{
    public partial class Login : System.Web.UI.Page
    {
        readonly UserServiceClient userService = new UserServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Comprobar si el usuario ya ha iniciado sesión y redirigirlo si es necesario
                if (Session["UserId"] != null)
                {
                    RedirectBasedOnRole();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                int userId = userService.Login(username, password);

                if (userId > 0)
                {
                    // El usuario se autenticó correctamente
                    // Obtener la información del usuario
                    User user = userService.GetUserById(userId);

                    if (user != null)
                    {
                        // Almacenar el objeto de usuario en la sesión
                        Session["UserId"] = user.ID_Usuario;
                        Session["RoleId"] = user.ID_Rol;

                        // Redirigir al usuario según su rol
                        RedirectBasedOnRole();
                    }
                    else
                    {
                        // Error al obtener la información del usuario
                        // Manejar el error o mostrar un mensaje
                        ShowErrorMessage("Error al obtener la información del usuario.");
                    }
                }
                else
                {
                    // La autenticación falló
                    // Manejar credenciales inválidas o mostrar un mensaje
                    ShowErrorMessage("Credenciales inválidas. Inténta de nuevo.");
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o mostrar un mensaje de error
                ShowErrorMessage("Se produjo un error durante el inicio de sesión. Por favor, inténtelo de nuevo más tarde.");
            }
        }

        private void RedirectBasedOnRole()
        {
            // Verificar si tanto UserId como RoleId existen en la sesión
            if (Session["UserId"] != null && Session["RoleId"] != null)
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                int roleId = Convert.ToInt32(Session["RoleId"]);

                // Redirigir según el rol
                if (roleId == 1) 
                {
                    // Suponiendo que el rol 1 es para administradores
                    // Redirigir a la página de administrador
                    Response.Redirect("~/AdminPage.aspx"); 
                }
                else if (roleId == 2) 
                {
                    // Redirigir a la página de cliente
                    Response.Redirect("~/Default.aspx"); 
                }
                else
                {
                    Response.Redirect("~/Default.aspx"); 
                }
            }
            else
            {
                ShowErrorMessage("Error al redirigir. Por favor, inicie sesión primero.");
            }
        }

        private void ShowErrorMessage(string message)
        {
            hdnToastMessage.Value = message;
        }
    }
}