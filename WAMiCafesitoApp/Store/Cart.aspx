<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WAMiCafesitoApp.Store.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container my-5">
        <div class="d-flex align-items-start">
            <div class="col-md-9">
                <h2 class="mb-3">Carrito de Compras</h2>
                <asp:HiddenField ID="hdnToastMessage" runat="server" />
                <asp:HiddenField ID="hdnToastType" runat="server" />

                <asp:GridView ID="gvCart" runat="server"
                    AutoGenerateColumns="false" CssClass="table cart-table">
                    <Columns>
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <div class="d-flex">
                                    <div class="product-img">
                                        <img src='<%# Eval("Imagen") %>' alt='<%# Eval("Nombre") %>' onerror="this.onerror=null; this.src='/Assets/Images/Default.png';" />
                                    </div>
                                    <div>

                                        <div class="product-name"><%# Eval("Nombre") %></div>
                                        <div class="product-desc">
                                            <%# Eval("Descripcion") %>
                                        </div>
                                        <div class="product-cat mt-3"><%# Eval("Categoria") %></div>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:TemplateField>

                        
                        <asp:BoundField
                            DataField="PrecioUnitario"
                            HeaderText="Precio"
                            DataFormatString="{0:C}" />

                        <asp:TemplateField HeaderText="Cantidad">
                            <ItemTemplate>
                                <div class="d-flex align-items-center px-3">
                                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Cantidad") %>' Width="38px" CssClass="form-control me-2"></asp:TextBox>
                                    <asp:LinkButton ID="lnkUpdate" runat="server" OnCommand="btnUpdate_Command" CommandArgument='<%# Eval("ID_Carrito") %>'>
                                    <i class="fa-solid fa-arrows-rotate"></i>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="TotalPrice" HeaderText="Total" DataFormatString="{0:C}" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" OnCommand="btnDelete_Command" CommandArgument='<%# Eval("ID_Carrito") %>' CssClass="text-danger">
                                 <i class="fa-regular fa-trash-can"></i>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnClearCart" CssClass="btn btn-danger btn-clear-cart" OnClick="btnClearCart_Click" runat="server" Text="Limpiar Carrito" />
            </div>
            <div class="col-md-3 ms-4 cart-summary">
                <h6>Resumen de Orden</h6>
                <div class="d-flex justify-content-between cart-row">
                    <span class="cart-label">Subtotal</span>
                    <span class="cart-value">
                        <asp:Label ID="lblSubTotal" runat="server" Text="Label"></asp:Label>
                    </span>
                </div>
                <div class="d-flex justify-content-between cart-row">
                    <span class="cart-label">IVA 13%</span>
                    <span class="cart-value">
                        <asp:Label ID="lblTaxes" runat="server" Text="Label"></asp:Label>
                    </span>
                </div>
                <div class="d-flex justify-content-between cart-total">
                    <span>Total</span>
                    <span>
                        <asp:Label ID="lblTotal" runat="server" Text="Label"></asp:Label>
                    </span>
                </div>
                <div class="cart-actions">
                    <asp:Button ID="btnCheckout" CssClass="btn btn-light shadow-none me-1 btn-add-to-cart px-4" OnClick="btnCheckout_Click" runat="server" Text="Procesar Orden" />
                </div>
                <div class="cart-actions">
                    <asp:LinkButton ID="lnkContinueShopping" runat="server" OnClick="lnkContinueShopping_Click" CssClass="lnk-continue-shopping">Continuar Comprando</asp:LinkButton>
                </div>
            </div>
        </div>

    </div>
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
