<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="WAMiCafesitoApp.Admin.OrderDetailPage" %>

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
                <div class="card mb-3 me-4">
                    <div class="card-body">
                        <h5 class="card-title pb-3">Información d la Orden</h5>
                        <div class="card-text d-flex">
                            <div class="card-label">ID:</div>
                            <asp:Label ID="lblOrderID" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">Usuario:</div>
                            <asp:Label ID="lblUser" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">Fecha:</div>
                            <asp:Label ID="lblOrderDate" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">No de Factura:</div>
                            <asp:Label ID="lblInvoice" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">Sub Total:</div>
                            <asp:Label ID="lblSubTotal" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">IVA 13%:</div>
                            <asp:Label ID="lblTaxes" runat="server" />
                        </div>
                        <div class="card-text d-flex">
                            <div class="card-label">Total:</div>
                            <asp:Label ID="lblTotal" runat="server" />
                        </div>

                    </div>
                </div>
                <div>
                    <h5>Detalle de la Orden</h5>
                    <asp:GridView ID="gvOrderDetails" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Producto">
                                <ItemTemplate>
                                    <div class="d-flex">
                                        <div class="product-img small-img">
                                            <img src='<%# Eval("Imagen") %>' alt='<%# Eval("Nombre") %>' onerror="this.onerror=null; this.src='/Assets/Images/Default.png';" />
                                        </div>
                                        <div>

                                            <div class="product-name"><%# Eval("Nombre") %></div>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField
                                DataField="PrecioUnitario"
                                HeaderText="Precio"
                                DataFormatString="{0:C}" />
                            <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="{0:C}" />
                        </Columns>
                    </asp:GridView>
                    <div class="card-text d-flex justify-content-between align-items-center">
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
