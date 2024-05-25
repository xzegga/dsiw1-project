<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="WAMiCafesitoApp.Store.CategoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container pt-3">
            <header class="mb-4">
                <h3>
                    <asp:Label ID="lblCategoryName" runat="server"></asp:Label>
                </h3>
            </header>

            <asp:HiddenField ID="hdnToastMessage" runat="server" />
            <asp:HiddenField ID="hdnToastType" runat="server" />
            <div class="row">
                <asp:Repeater ID="featuredProductsRepeater" runat="server" OnItemDataBound="featuredProductsRepeater_ItemDataBound">
                    <itemtemplate>
                        <div class="col-lg-3 col-md-6 col-sm-6 d-flex mb-5">
                            <div class="card w-100 my-2 shadow-2-strong">
                                <img src='/Assets/Images/<%# Eval("ID_Producto") %>.png'
                                    class="card-img-top" 
                                    style="aspect-ratio: 1 / 1"
                                    onerror="this.onerror=null; this.src='/Assets/Images/Default.png';"
                                    />
                                <div class="card-body d-flex flex-column">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <span class="a-price d-flex align-items-start" aria-hidden="true">
                                        <span class="a-price-symbol">$</span>
                                        <span class="a-price-whole"><%# Convert.ToInt32(Math.Floor(Convert.ToDouble(Eval("Precio")))) %></span>
                                        <span class="a-price-fraction"><%# String.Format("{0:00}", GetFractionalPart(Eval("Precio"))) %></span>
                                    </span>
                                    <p class="card-text"><%# Eval("Descripcion", "{0:C}") %></p>
                                    <div class="d-flex align-items-end py-2 px-0 mt-auto gap-2">
                                        <asp:HyperLink ID="btnViewDetail"
                                            runat="server"
                                            CssClass="btn btn-light shadow-none me-1 btn-view-details">
                                            <i class="fa-solid fa-magnifying-glass"></i>Detalle 
                                        </asp:HyperLink>
                                        <asp:LinkButton
                                            CssClass="btn btn-light shadow-none me-1 btn-add-to-cart px-4"
                                            ID="btnAddToCart"
                                            runat="server"
                                            CommandName="AddToCart"
                                            CommandArgument='<%# Eval("ID_Producto") %>'
                                            OnClick="btnAddToCart_Click">
                                            <i class="fa-solid fa-cart-shopping"></i>Ordenar</asp:LinkButton>
                                    </div>




                                </div>
                            </div>
                        </div>
                    </itemtemplate>
                </asp:Repeater>
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
