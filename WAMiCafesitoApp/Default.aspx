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
                    <p class="lead">Disfruta descubriendo tus granos favoritos,
                        <br />
                        método de preparación e inventando tu receta..</p>
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
                <h3>New products</h3>
            </header>

            <div class="row">
                <div class="col-lg-3 col-md-6 col-sm-6 d-flex">
                    <div class="card w-100 my-2 shadow-2-strong">
                        <img src="https://bootstrap-ecommerce.com/bootstrap5-ecommerce/images/items/1.webp" class="card-img-top" style="aspect-ratio: 1 / 1" />
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title">GoPro HERO6 4K Action Camera - Black</h5>
                            <p class="card-text">$790.50</p>
                            <div class="card-footer d-flex align-items-end pt-3 px-0 pb-0 mt-auto">
                                <a href="#!" class="btn btn-primary shadow-0 me-1">Add to cart</a>
                                <a href="#!" class="btn btn-light border px-2 pt-2 icon-hover"><i class="fas fa-heart fa-lg text-secondary px-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 d-flex">
                    <div class="card w-100 my-2 shadow-2-strong">
                        <img src="https://bootstrap-ecommerce.com/bootstrap5-ecommerce/images/items/2.webp" class="card-img-top" style="aspect-ratio: 1 / 1" />
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title">Canon camera 20x zoom, Black color EOS 2000</h5>
                            <p class="card-text">$320.00</p>
                            <div class="card-footer d-flex align-items-end pt-3 px-0 pb-0 mt-auto">
                                <a href="#!" class="btn btn-primary shadow-0 me-1">Add to cart</a>
                                <a href="#!" class="btn btn-light border px-2 pt-2 icon-hover"><i class="fas fa-heart fa-lg text-secondary px-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 d-flex">
                    <div class="card w-100 my-2 shadow-2-strong">
                        <img src="https://bootstrap-ecommerce.com/bootstrap5-ecommerce/images/items/3.webp" class="card-img-top" style="aspect-ratio: 1 / 1" />
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title">Xiaomi Redmi 8 Original Global Version 4GB</h5>
                            <p class="card-text">$120.00</p>
                            <div class="card-footer d-flex align-items-end pt-3 px-0 pb-0 mt-auto">
                                <a href="#!" class="btn btn-primary shadow-0 me-1">Add to cart</a>
                                <a href="#!" class="btn btn-light border px-2 pt-2 icon-hover"><i class="fas fa-heart fa-lg text-secondary px-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 d-flex">
                    <div class="card w-100 my-2 shadow-2-strong">
                        <img src="https://bootstrap-ecommerce.com/bootstrap5-ecommerce/images/items/4.webp" class="card-img-top" style="aspect-ratio: 1 / 1" />
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title">Apple iPhone 12 Pro 6.1" RAM 6GB 512GB Unlocked</h5>
                            <p class="card-text">$120.00</p>
                            <div class="card-footer d-flex align-items-end pt-3 px-0 pb-0 mt-auto">
                                <a href="#!" class="btn btn-primary shadow-0 me-1">Add to cart</a>
                                <a href="#!" class="btn btn-light border px-2 pt-2 icon-hover"><i class="fas fa-heart fa-lg text-secondary px-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 d-flex">
                    <div class="card w-100 my-2 shadow-2-strong">
                        <img src="https://bootstrap-ecommerce.com/bootstrap5-ecommerce/images/items/5.webp" class="card-img-top" style="aspect-ratio: 1 / 1" />
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title">Apple Watch Series 1 Sport Case 38mm Black</h5>
                            <p class="card-text">$790.50</p>
                            <div class="card-footer d-flex align-items-end pt-3 px-0 pb-0 mt-auto">
                                <a href="#!" class="btn btn-primary shadow-0 me-1">Add to cart</a>
                                <a href="#!" class="btn btn-light border px-2 pt-2 icon-hover"><i class="fas fa-heart fa-lg text-secondary px-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 d-flex">
                    <div class="card w-100 my-2 shadow-2-strong">
                        <img src="https://bootstrap-ecommerce.com/bootstrap5-ecommerce/images/items/6.webp" class="card-img-top" style="aspect-ratio: 1 / 1" />
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title">T-shirts with multiple colors, for men and lady</h5>
                            <p class="card-text">$120.00</p>
                            <div class="card-footer d-flex align-items-end pt-3 px-0 pb-0 mt-auto">
                                <a href="#!" class="btn btn-primary shadow-0 me-1">Add to cart</a>
                                <a href="#!" class="btn btn-light border px-2 pt-2 icon-hover"><i class="fas fa-heart fa-lg text-secondary px-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 d-flex">
                    <div class="card w-100 my-2 shadow-2-strong">
                        <img src="https://bootstrap-ecommerce.com/bootstrap5-ecommerce/images/items/7.webp" class="card-img-top" style="aspect-ratio: 1 / 1" />
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title">Gaming Headset 32db Blackbuilt in mic</h5>
                            <p class="card-text">$99.50</p>
                            <div class="card-footer d-flex align-items-end pt-3 px-0 pb-0 mt-auto">
                                <a href="#!" class="btn btn-primary shadow-0 me-1">Add to cart</a>
                                <a href="#!" class="btn btn-light border icon-hover px-2 pt-2"><i class="fas fa-heart fa-lg text-secondary px-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-sm-6 d-flex">
                    <div class="card w-100 my-2 shadow-2-strong">
                        <img src="https://bootstrap-ecommerce.com/bootstrap5-ecommerce/images/items/8.webp" class="card-img-top" style="aspect-ratio: 1 / 1" />
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title">T-shirts with multiple colors, for men and lady</h5>
                            <p class="card-text">$120.00</p>
                            <div class="card-footer d-flex align-items-end pt-3 px-0 pb-0 mt-auto">
                                <a href="#!" class="btn btn-primary shadow-0 me-1">Add to cart</a>
                                <a href="#!" class="btn btn-light border px-2 pt-2 icon-hover"><i class="fas fa-heart fa-lg text-secondary px-1"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
