<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="WAMiCafesitoApp.Admin.OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container my-5">
            <asp:HiddenField ID="hdnToastMessage" runat="server" />
            <asp:HiddenField ID="hdnToastType" runat="server" />

            <div class="d-flex">
                <div class="card mb-3">
                    <div class="card-body">
                        <h5 class="card-title pb-3">Información d la Orden</h5>
                        <div class="card-text d-flex">
                            <div class="card-label">Order ID:</div>
                            <asp:Label ID="lblOrderID" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">User ID:</div>
                            <asp:Label ID="lblUser" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">Order Date:</div>
                            <asp:Label ID="lblOrderDate" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">Invoice:</div>
                            <asp:Label ID="lblInvoice" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">SubTotal:</div>
                            <asp:Label ID="lblSubTotal" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">Status:</div>
                            <div class="d-flex update-status">
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select me-2">
                                    <asp:ListItem Value="Recibida" Text="Recibida"></asp:ListItem>
                                    <asp:ListItem Value="Procesando" Text="Procesando"></asp:ListItem>
                                    <asp:ListItem Value="Enviada" Text="Enviada"></asp:ListItem>
                                    <asp:ListItem Value="Entregada" Text="Entregada"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:Button ID="btnUpdateStatus" runat="server" CssClass="btn btn-primary btn-sm" Text="Cambiar" OnClick="btnUpdateStatus_Click" />
                            </div>

                        </div>
                    </div>
                </div>
                <asp:GridView ID="gvOrderDetails" runat="server" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="ID_Detalle" HeaderText="Detail ID" />
                        <asp:BoundField DataField="ID_Producto" HeaderText="Product ID" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Quantity" />
                        <asp:BoundField DataField="PrecioUnitario" HeaderText="Unit Price" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
                    </Columns>
                </asp:GridView>
            </div>


        </div>
    </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterScripts" runat="server">
    <script src="../Assets/Scripts/ErrMesasges.js" type="text/javascript"></script>
    <script>
        var toastMessage = document.getElementById('<%= hdnToastMessage.ClientID %>');
        var toastType = document.getElementById('<%= hdnToastType.ClientID %>');
        if (toastMessage) {
            showAnimatedToast(toastMessage, toastType);
        }
    </script>
</asp:Content>
