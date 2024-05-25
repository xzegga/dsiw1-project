<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="WAMiCafesitoApp.Admin.Categories" %>

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
            <div class="mt-4">

                <!-- Formulario para agregar nueva categoría -->
                <div class="card mb-3">
                    <div class="card-body">
                        <h5 class="card-title">Agregar Nueva Categoría</h5>
                        <div class="mb-3">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtDescripcion" class="form-label">Descripción</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnAddCategory" runat="server" CssClass="btn btn-success" Text="Agregar Categoría" OnClick="btnAddCategory_Click" />
                    </div>
                </div>

                <h4 class="mb-3 mt-5">Listado de Categorías</h4>

                <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" CssClass="table table-striped"
                    OnRowEditing="gvCategorias_RowEditing"
                    OnRowUpdating="gvCategorias_RowUpdating"
                    OnRowCancelingEdit="gvCategorias_RowCancelingEdit"
                    DataKeyNames="ID_Categoria">
                    <Columns>
                        <asp:BoundField DataField="ID_Categoria" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Acciones
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-primary rounded-pill px-3 me-4">
                            <i class="fas fa-edit"></i> Editar
                                </asp:LinkButton>

                                <a href="#" class="text-danger" onclick="setDeleteCategoryId('<%# Eval("ID_Categoria") %>')" data-bs-toggle="modal" data-bs-target="#confirmationModal">
                                    <i class="fa-regular fa-trash-can"></i>
                                </a>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:LinkButton ID="btnUpdate" runat="server" CommandName="Update" CssClass="btn btn-success rounded-pill px-3 me-4">
                            <i class="fas fa-save"></i> Actualizar
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnCancel" runat="server" CommandName="Cancel" CssClass="btn btn-secondary rounded-pill px-3 me-4">
                            <i class="fas fa-times"></i> Cancelar
                                </asp:LinkButton>
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>

            <!-- Modal para confirmación de eliminación -->
            <div class="modal fade" id="confirmationModal" tabindex="-1" aria-labelledby="confirmationModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="confirmationModalLabel">Eliminar Categoría</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                        </div>
                        <div class="modal-body">
                            ¿Está completamente seguro de que desea eliminar la categoría seleccionada? Esta acción es irreversible.
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                            <asp:Button ID="confirmButton" runat="server" CssClass="btn btn-danger" Text="Confirmar" OnClick="btnDelete_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hfDeleteCategoryId" runat="server" />
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

        function setDeleteCategoryId(categoryId) {
            var hiddenField = document.getElementById('<%= hfDeleteCategoryId.ClientID %>');
            hiddenField.value = categoryId;
        }
    </script>
</asp:Content>
