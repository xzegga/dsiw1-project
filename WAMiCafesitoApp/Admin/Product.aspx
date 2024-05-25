<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="WAMiCafesitoApp.Admin.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container pt-3">
            <h2>Categorías</h2>

            <asp:HiddenField ID="hdnToastMessage" runat="server" />
            <asp:HiddenField ID="hdnToastType" runat="server" />
            <asp:HiddenField ID="hdnProductId" runat="server" />
            <div class="mt-4">
                <div class="row">
                    <div class="col-md-4 pe-4">
                        <a href="#" data-bs-toggle="modal" data-bs-target="#imageModal">
                            <asp:Image ID="imgProduct" runat="server" CssClass="img-fluid rounded"
                                Style="aspect-ratio: 1 / 1"
                                onerror="this.onerror=null; this.src='/Assets/Images/Default.png';" />
                        </a>

                        <!-- Lightbox Modal -->
                        <div class="modal fade" id="imageModal" tabindex="-1" aria-labelledby="imageModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-lg p-0">

                                <div class="modal-content p-0">
                                    <button type="button" class="modal-close-icon" data-bs-dismiss="modal">
                                        <i class="fa-regular fa-circle-xmark"></i>
                                    </button>
                                    <div class="modal-body p-0">
                                        <asp:Image ID="imgProductThumb" runat="server" CssClass="img-fluid" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-8 px-4 border-start">
                        <div class="mb-3">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <label for="txtDescripcion" class="form-label">Descripción</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                        </div>
                        <label for="txtPrecio" class="form-label">Precio</label>
                        <div class="input-group mb-3">
                            <span class="input-group-text">$</span>                            
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <label for="ddlCategoria" class="form-label">Categoría</label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select">
                            </asp:DropDownList>
                        </div>

                        <div class="mb-3 form-check">
                            <asp:CheckBox ID="chkDestacado" runat="server" />
                            <label class="form-check-label" for="chkDestacado">Destacado</label>
                        </div>

                        <div class="mb-3">
                            <label for="fuImagen" class="form-label">Imagen</label>
                            <asp:FileUpload ID="fuImagen" runat="server" CssClass="form-control" />
                        </div>
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />

                    </div>
                </div>
            </div>
        </div>
    </section>

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
