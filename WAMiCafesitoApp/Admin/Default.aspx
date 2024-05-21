<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WAMiCafesitoApp.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container my-5">
            <h2>Orders</h2>

            <asp:HiddenField ID="hdnToastMessage" runat="server" />
            <asp:HiddenField ID="hdnToastType" runat="server" />
            <asp:GridView ID="OrdersGridView" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ID_Pedido" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Producto">
                        <ItemTemplate>
                            <div>
                                <%# Eval("User") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="FechaPedido" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:BoundField DataField="Factura" HeaderText="Factura" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="d-flex justify-content-end align-items-center pe-4">
                                <asp:LinkButton ID="lnkViewOrder" runat="server"
                                    OnCommand="btnDelete_Command"
                                    CommandArgument='<%# Eval("ID_Pedido") %>'
                                    CssClass="btn btn-primary me-4">
                                        <i class="fa-regular fa-eye"></i> Ver Detalle
                                </asp:LinkButton>


                                <a class="text-danger" data-bs-toggle="modal" data-bs-target="#confirmationModal">
                                    <i class="fa-regular fa-trash-can"></i>
                                </a>

                                <div class="modal fade" id="confirmationModal" tabindex="-1" aria-labelledby="confirmationModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title" id="confirmationModalLabel">Eliminar Orden</h5>
                                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                                            </div>
                                            <div class="modal-body">
                                                ¿Está completamente seguro de que desea eliminar esta orden? Esta acción es irreversible.
                                     
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>

                                                <asp:Button ID="confirmButton" runat="server"
                                                    OnCommand="btnDelete_Command"
                                                    CommandArgument='<%# Eval("ID_Pedido") %>'
                                                    CssClass="btn btn-danger" Text="Confirmar" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:TemplateField>
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
