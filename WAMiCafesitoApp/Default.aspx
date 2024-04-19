<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WAMiCafesitoApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
    <div class="container-full hero py-5">
        <div class="gradient-overlay">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 mt-5 pt-3">
                        <h1 class="display-4">¡Descubre el
                        <br />
                            V60 Hario!</h1>
                        <p class="lead">
                            Disfruta descubriendo tus granos favoritos,
                        <br />
                            método de preparación e inventando tu receta..
                        </p>
                        <div class="mt-4 d-flex gap-3">
                            <a href="#" class="btn btn-comprar btn-lg rounded-pill mr-3 text-white px-4"><i class="fas fa-shopping-cart me-2"></i>Ordena Ahora</a>
                            <a href="#" class="btn btn-informacion btn-lg rounded-pill text-white px-4 ml-4">Más Información</a>
                        </div>
                    </div>
                    <div class="col-md-6 d-flex justify-content-center">
                        <img src="/Assets/Images/hero-home.png" class="img-fluid hero-img" alt="V60 Ario">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container my-5">
            <header class="mb-4">
                <h3>PRODUCTOS DESTACADOS</h3>
            </header>

            <div class="row">
                <asp:Repeater ID="featuredProductsRepeater" runat="server">
                    <ItemTemplate>
                        <div class="col-lg-3 col-md-6 col-sm-6 d-flex mb-5">
                            <div class="card w-100 my-2 shadow-2-strong">
                                <img src='/Assets/Images/<%# Eval("ID_Producto") %>.png' class="card-img-top" style="aspect-ratio: 1 / 1" />
                                <div class="card-body d-flex flex-column">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <span class="a-price d-flex align-items-start" aria-hidden="true">
                                        <span class="a-price-symbol">$</span>
                                        <span class="a-price-whole"><%# String.Format("{0:N0}", Convert.ToInt32(Eval("Precio"))) %></span>
                                        <span class="a-price-fraction"><%# String.Format("{0:00}", GetFractionalPart(Eval("Precio"))) %></span>
                                    </span>
                                    <p class="card-text"><%# Eval("Descripcion", "{0:C}") %></p>
                                    <div class="d-flex align-items-end py-2 px-0 mt-auto">
                                        <asp:HyperLink ID="btnAgregarCarrito" runat="server" CssClass="btn btn-light shadow-none me-1 a-add-to-cart" NavigateUrl="#!">
                                            <i class="fa-solid fa-cart-shopping"></i> Agregar al carrito
                                        </asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>
</asp:Content>
