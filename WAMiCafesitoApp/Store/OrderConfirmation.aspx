<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="WAMiCafesitoApp.Store.OrderConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container my-5 text-center">
            <header class="mb-4">
                <h3>Pedido realizado con éxito
                </h3>
                <p>
                    Gracias por tu compra, tu pedido ha sido enviado con éxito. <br />En breve uno de nuestros agentes comerciales se comunicará contigo.
                </p>
                <p>
                    <a href="/Store/OrderList.aspx" class="btn btn-primary">Ver historial de pedidos</a>
                </p>
            </header>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterScripts" runat="server">
</asp:Content>
