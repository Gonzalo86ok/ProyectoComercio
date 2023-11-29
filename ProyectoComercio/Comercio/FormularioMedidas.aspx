<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioMedidas.aspx.cs" Inherits="Comercio.FormularioMedidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6">
        <div class="md-3">
            <asp:ScriptManager runat="server" />
            <div class="form-container border border-secondary p-3">
                <h5>Agregar una Medida</h5>
                <asp:Label runat="server" Text="Medida de producto:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="TxtMedida" CssClass="form-control" MaxLength="20" />

                <div class="form-group">
                    <asp:Label runat="server" ID="lblMensajeError" CssClass="text-danger" Visible="false" />
                </div>

                <div class="button-container mt-4">
                    <div class="btn-group">
                        <asp:Button runat="server" ID="btnAgregarMedida" OnClick="btnAgregarMedida_Click" Text="Agregar" CssClass="btn btn-outline-primary btn-block mt-4" Style="margin-right: 10px;" />
                        <asp:Button runat="server" ID="btnCancelarMedida" OnClick="btnCancelarMedida_Click" Text="Cancelar" CssClass="btn btn-outline-primary btn-block mt-4" Style="margin-right: 10px;" />
                        <asp:Button Text="Eliminar" ID="btnEliminarMedida" OnClick="btnEliminarMedida_Click" CssClass="btn btn-danger btn-block mt-4" runat="server" />
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        <div class="md-3">
                            <%if (ConfirmaEliminacion)
                                {%>
                            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                            <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
