<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WAMiCafesitoApp.Login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <title>Acceso a usuarios MiCafesito.com</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css" integrity="sha512-SnH5WK+bZxgPHs44uWIX+LLJAJ9/2PkPKZ5QiAj6Ta86w+fsb2TkcmfRyVX3pBnMFcV7oQPJkl9QevSCWr3W6A==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <link href="/Assets/Styles/style.css" rel="stylesheet" />
    <link href="/Assets/Styles/login.css" rel="stylesheet" />
</head>
<body>
    <section class="h-100 gradient-form" style="background-color: #eee;">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
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
                                        <form id="form1" runat="server" class="signin-form">
                                            <asp:HiddenField ID="hdnToastMessage" runat="server" />
                                            <h1 class="login-text">Ingresa a tu cuenta</h1>

                                            <div class="form-outline mb-4">
                                                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" />
                                                <asp:Label ID="lblUser" runat="server" AssociatedControlID="txtUser" CssClass="form-label">Correo electrónico</asp:Label>
                                            </div>

                                            <div class="form-outline mb-4">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                                                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" CssClass="form-label">Contraseña</asp:Label>
                                            </div>

                                            <div class="pt-1 mb-5 pb-1">
                                                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-comprar btn-md rounded-pill mr-3 text-white px-4" OnClick="btnLogin_Click" />
                                                <a class="text-muted" href="#!">¿Olvidaste tu contraseña?</a>
                                            </div>

                                            <div class="d-flex align-items-center justify-content-center pb-4">
                                                <p class="mb-0 me-2">¿No tienes una cuenta?</p>
                                                <button type="button" class="btn btn-link">Regístrate</button>
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
    </script>



</body>
</html>
