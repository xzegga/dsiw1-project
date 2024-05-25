<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="WAMiCafesitoApp.Admin.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container pt-3">
            <div class="d-flex align-items-center justify-content-between">
                <h2>Productos</h2>
                <asp:LinkButton ID="lnkAddNew" runat="server" CssClass="btn rounded-pill btn-success px-4" OnClick="lnkAddNew_Click">Agregar Producto</asp:LinkButton>
            </div>


            <asp:HiddenField ID="hdnToastMessage" runat="server" />
            <asp:HiddenField ID="hdnToastType" runat="server" />
            <div class="mt-4">
                <asp:GridView ID="ProductsGridView" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="ID_Producto" HeaderText="ID" />
                        <asp:TemplateField HeaderText="Product Name">
                            <ItemTemplate>
                                <div class="d-flex">
                                    <div class="product-img">
                                        <img src='<%# Eval("Imagen") %>' alt='<%# Eval("Nombre") %>' onerror="this.onerror=null; this.src='/Assets/Images/Default.png';" />
                                    </div>
                                    <div>

                                        <div class="product-name"><%# Eval("Nombre") %></div>
                                        <div class="product-desc pb-3">
                                            <%# Eval("Descripcion") %>
                                        </div>
                                        <span class="badge rounded-pill text-bg-secondary px-3 py-1 fw-normal">
                                            <%# Eval("Categoria") %>
                                        </span>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                        <asp:TemplateField HeaderText="Destacado">
                            <ItemTemplate>
                                <%# (bool)Eval("Destacado") ? "<i class='fas fa-check'></i>" : "" %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="d-flex justify-content-end align-items-center pe-4">
                                    <asp:LinkButton ID="lnkViewOrder" runat="server"
                                        OnCommand="lnkViewOrder_Command"
                                        CommandArgument='<%# Eval("ID_Producto") %>'
                                        CssClass="btn rounded-pill btn-primary px-3 me-4">
                                        Ver Detalle
                                    </asp:LinkButton>

                                    <a href="#" class="text-danger" onclick="setDeleteCategoryId('<%# Eval("ID_Producto") %>')" data-bs-toggle="modal" data-bs-target="#confirmationModal">
                                        <i class="fa-regular fa-trash-can"></i>
                                    </a>
                                </div>

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>


        <!-- Modal para confirmación de eliminación -->
        <div class="modal fade" id="confirmationModal" tabindex="-1" aria-labelledby="confirmationModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="confirmationModalLabel">Eliminar Producto</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                    </div>
                    <div class="modal-body">
                        ¿Está completamente seguro de que desea eliminar el producto seleccionado? Esta acción es irreversible.
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                        <asp:Button ID="confirmButton" runat="server" CssClass="btn btn-danger" Text="Confirmar" OnClick="btnDelete_Click" />
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hfDeleteProductId" runat="server" />
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


        function setDeleteCategoryId(categoryId) {
            var hiddenField = document.getElementById('<%= hfDeleteProductId.ClientID %>');
            hiddenField.value = categoryId;
        }
    </script>
</asp:Content>
