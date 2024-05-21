using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WAMiCafesitoApp.ServiceApi;
using WAMiCafesitoApp.Services;

namespace WAMiCafesitoApp
{
    public partial class Signup : System.Web.UI.Page
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

        private void RedirectBasedOnRole()
        {
            // Verificar si tanto UserId como RoleId existen en la sesión
            if (Session["UserId"] != null && Session["RoleId"] != null)
            {
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            // Validar el correo electrónico
            if (!Validator.ValidateEmail(txtUser.Text))
            {
                ShowErrorMessage("Correo electrónico no válido.");
                return;
            }

            // Validar nombre
            if (!Validator.ValidateString(txtNombre.Text))
            {
                ShowErrorMessage("Nombre no válido.");
                return;
            }

            // Validar apellido
            if (!Validator.ValidateString(txtApellido.Text))
            {
                ShowErrorMessage("Apellido no válido.");
                return;
            }

            // Validar número de teléfono
            if (!Validator.ValidatePhoneNumber(txtTelefono.Text))
            {
                ShowErrorMessage("Número de teléfono no válido.");
                return;
            }

            // Validar fecha de nacimiento
            if (!Validator.ValidateDate(txtBirthday.Value))
            {
                ShowErrorMessage("Fecha de nacimiento no válida.");
                return;
            }

            // Validar contraseña y confirmar contraseña
            if (!Validator.ValidatePassword(txtPassword.Text, txtConfirmPassword.Text))
            {
                lblPasswordFail.Visible = true;
                ShowErrorMessage("Contraseña no válida o no coincide con la confirmación.");
                return;
            }
            else
            {
                lblPasswordFail.Visible = false;
            }

            User user = new User
            {
                Email = txtUser.Text,
                Password = txtPassword.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Fecha_Nacimiento = Convert.ToDateTime(txtBirthday.Value),
                Estado = "A",
                ID_Rol = 2

            };

            userService.AddUser(user);
            ShowErrorMessage("Usuario creado con éxito.");
            Response.Redirect("~/Login.aspx");
        }
    }
}