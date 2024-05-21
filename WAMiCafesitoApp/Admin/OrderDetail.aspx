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

            <div class="card mb-3">
                <div class="card-body">
                    <h5 class="card-title">Order Information</h5>
                    <p class="card-text"><strong>Order ID:</strong>
                        <asp:Label ID="lblOrderID" runat="server" /></p>
                    <p class="card-text"><strong>User ID:</strong>
                        <asp:Label ID="lblUserID" runat="server" /></p>
                    <p class="card-text"><strong>Order Date:</strong>
                        <asp:Label ID="lblOrderDate" runat="server" /></p>
                    <p class="card-text"><strong>Invoice:</strong>
                        <asp:Label ID="lblInvoice" runat="server" /></p>
                    <p class="card-text"><strong>SubTotal:</strong>
                        <asp:Label ID="lblSubTotal" runat="server" /></p>
                    <p class="card-text">
                        <strong>Status:</strong>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                            <asp:ListItem Value="Pending" Text="Pending"></asp:ListItem>
                            <asp:ListItem Value="Completed" Text="Completed"></asp:ListItem>
                            <asp:ListItem Value="Cancelled" Text="Cancelled"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnUpdateStatus" runat="server" CssClass="btn btn-primary btn-sm" Text="Update Status" />
                    </p>
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
