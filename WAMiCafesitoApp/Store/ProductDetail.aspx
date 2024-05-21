<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="WAMiCafesitoApp.Store.ProductDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hdnToastMessage" runat="server" />
    <asp:HiddenField ID="hdnToastType" runat="server" />
    <section>
        <div class="container my-5">
            <div class="row">
                <div class="col-lg-4">
                    <!-- Product Image with Lightbox -->
                    <a href="#" data-bs-toggle="modal" data-bs-target="#imageModal">
                        <asp:Image ID="imgProduct" runat="server" CssClass="img-fluid rounded" />
                    </a>

                    <!-- Lightbox Modal -->
                    <div class="modal fade" id="imageModal" tabindex="-1" aria-labelledby="imageModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-lg p-0">

                            <div class="modal-content p-0">
                                <button type="button" class="modal-close-icon" data-bs-dismiss="modal">
                                    <i class="fa-regular fa-circle-xmark"></i>
                                </button>
                                <div class="modal-body p-0">
                                    <img id="modalImage" class="img-fluid" alt="Product Image">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-7 ps-4 pt-4">
                    <h2 class="mb-0">
                        <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>
                        En carrito
                        <asp:Label ID="txtCart" runat="server" Text=""></asp:Label>
                    </h2>
                    <div class="d-flex align-items-center gap-2 mb-4">
                        <strong>Categoria:</strong>
                        <asp:Label ID="lblCategory" runat="server" Text=""></asp:Label>
                    </div>
                    <p class="lead mb-4">
                        <asp:Label ID="lblProductDescription" runat="server" Text=""></asp:Label>
                    </p>
                    <p class="lead">
                        <strong>Precio:</strong>
                        <span class="a-price d-flex align-items-start" aria-hidden="true">
                            <span class="a-price-symbol">$</span>
                            <asp:Label ID="lblPriceInteger" runat="server" CssClass="a-price-whole" Text=""></asp:Label>
                            <asp:Label ID="lblPriceDecimal" runat="server" CssClass="a-price-fraction" Text=""></asp:Label>
                        </span>
                    </p>

                    <div class="mb-4">
                        <!-- Quantity selection -->
                        <asp:Label ID="lblQuantity" runat="server" AssociatedControlID="txtQuantity" Text="Cantidad:" CssClass="form-label"></asp:Label>
                        <div class="d-flex align-items-center gap-3">
                            <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control max-80" Text="1" Type="Number" Min="1"></asp:TextBox>
                            <asp:LinkButton ID="btnAddToCart" runat="server" CssClass="btn btn-light shadow-none me-1 btn-add-to-cart px-4" OnClick="btnAddToCart_Click"><i class="fa-solid fa-cart-shopping"></i> Ordenar</asp:LinkButton>
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
