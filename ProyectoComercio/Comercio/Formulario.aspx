<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Comercio.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Formulario</h3>
    <!-- Formulario de agregar productos -->
    <div class="form-container border border-secondary p-3">
        <h5>Agregar Producto</h5>
        <div class="row">
            <div class="col-md-6">

                <asp:Label runat="server" Text="Código:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />

                <asp:Label runat="server" Text="Nombre:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />

                <asp:Label runat="server" Text="Descripción:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />

                <asp:Label runat="server" Text="Precio:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />

            </div>
            <div class="col-md-6">
                <div class="md-3">
                    <asp:Label runat="server" Text="Categoría preestablecida" CssClass="form-label" />
                    <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control">
                    </asp:DropDownList>

                    <asp:Label runat="server" Text="Fabricante preestablecido" CssClass="form-label" />
                    <asp:DropDownList runat="server" ID="ddlFabricante" CssClass="form-control">
                    </asp:DropDownList>

                    <asp:Label runat="server" Text="Medida preestablecida" CssClass="form-label" />
                    <asp:DropDownList runat="server" ID="ddlMedida" CssClass="form-control">
                    </asp:DropDownList>

                    <asp:Button runat="server" ID="btnAgregarProducto" OnClick="btnAgregarProducto_Click" Text="Agregar" CssClass="btn btn-outline-primary ml-2 mt-4 " Style="margin-right: 10px;" />
                    <asp:Button runat="server" ID="btnCancelar" OnClick="Cancelar_Click" Text="Cancelar" CssClass="btn btn-outline-primary ml-2 mt-4 " Style="margin-right: 10px;" />
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="row">
                <div class="col-6">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>

                            <div class="md-3">
                                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" runat="server" />
                            </div>
                            <div id="mensaje" runat="server" class="alert alert-danger" visible="false">
                                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                            </div>
                            <%if (ConfirmaEliminacion)
                                {%>
                            <div class="md-3">
                                <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                                <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                            </div>
                            <% } %>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
