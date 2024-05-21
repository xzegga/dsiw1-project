<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="WAMiCafesitoApp.Signup" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <title>Registro en MiCafesito.com</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css" integrity="sha512-SnH5WK+bZxgPHs44uWIX+LLJAJ9/2PkPKZ5QiAj6Ta86w+fsb2TkcmfRyVX3pBnMFcV7oQPJkl9QevSCWr3W6A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="/Assets/Styles/style.css" rel="stylesheet" />
    <link href="/Assets/Styles/login.css" rel="stylesheet" />
</head>
<body>
    <section style="background-color: #eee;">
        <div class="container py-5">
            <div class="row d-flex justify-content-center align-items-center">
                <div class="col-xl-10">
                    <div class="card rounded-3 text-black">
                        <div class="row g-0">
                            <div class="col-lg-6">
                                <div class="card-body p-md-5 mx-md-4">

                                    <div class="pb-1 pt-5 d-flex">
                                        <a href="/" target="_blank" class="d-flex gap-2 logo-link">
                                            <img src="/Assets/Images/logo.jpg" height="45" />
                                            <h1 class="logo-text">MiCafesito <span class="logo-text-small d-block">Enlínea</span></h1>
                                        </a>
                                    </div>
                                    <div>
                                        <form id="form1" runat="server" class="signup-form">
                                            <asp:HiddenField ID="hdnToastMessage" runat="server" />
                                            <h1 class="login-text">Regístrate</h1>

                                            <div class="form-floating mb-3">                                                
                                                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="Correo electrónico"/>
                                                <asp:Label ID="lblUser" runat="server" AssociatedControlID="txtUser">Correo electrónico</asp:Label>
                                            </div>

                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"/>
                                                <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre">Nombre</asp:Label>                                                
                                            </div>

                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido"/>
                                                <asp:Label ID="lblApellido" runat="server" AssociatedControlID="txtApellido">Apellido</asp:Label>
                                                
                                            </div>

                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono"/>
                                                <asp:Label ID="lblTelefono" runat="server" AssociatedControlID="txtTelefono">Teléfono</asp:Label>                                                
                                            </div>

                                            <div class="form-floating mb-3">
                                                <input type="text" class="form-control" runat="server" id="txtBirthday" placeholder="Fecha de Nacimient"/>
                                                <asp:Label ID="lblFechaNac" runat="server" AssociatedControlID="txtBirthday">Fecha de Nacimiento</asp:Label>
                                                
                                            </div>

                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Contraseña"/>
                                                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Contraseña</asp:Label>
                                                
                                            </div>

                                            <div class="form-floating mb-3">
                                                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirmar contraseña"/>
                                                <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtConfirmPassword">Confirmar contraseña</asp:Label>
                                                
                                            </div>
                                            <asp:Label ID="lblPasswordFail" runat="server" CssClass="text-danger" Visible="false">
                                                <div class="alert alert-danger" role="alert">
                                                    La contraseña debe contener al menos 8 caracteres, un número, una letra minúscula y una letra mayúscula.
                                                </div>
                                            </asp:Label>

                                            <div class="pt-1 mb-5 pb-1">
                                                <asp:Button ID="btnLogin" runat="server" Text="Regístrate" CssClass="btn btn-comprar btn-md rounded-pill mr-3 text-white px-4" OnClick="btnLogin_Click" />
                                            </div>
                                        </form>

                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6 d-flex align-items-center gradient-custom-2 img-logo">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <div class="toast-container position-fixed top-0 end-0 p-3">
        <div id="liveToast" class="toast bg-danger text-white" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="toast-body d-flex align-items-center">
                <i class="fas fa-exclamation-triangle fa-sm me-2"></i>
                <span id="toastMessage"></span>
            </div>
        </div>
    </div>

    <!-- Bootstrap JS from CDN (Optional, for certain Bootstrap components) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <link href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script>
        // Function to show the Bootstrap toast
        function showAnimatedToast(message) {
            var toast = new bootstrap.Toast(document.getElementById('liveToast'), {
                animation: true,
                autohide: true,
                delay: 3500000
            });

            var toastMessage = document.getElementById('toastMessage');
            toastMessage.innerText = message;

            // Show the toast with animation
            toast.show();
        }


        var toastMessage = document.getElementById('<%= hdnToastMessage.ClientID %>').value;
        if (toastMessage) {
            showAnimatedToast(toastMessage);
        }

        $(function () {
            $("#<%= txtBirthday.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1900:2024",
                dateFormat: "mm/dd/yy"
            });
        });
    </script>
</body>
</html>
